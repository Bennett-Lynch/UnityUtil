using System;

/// <summary>
/// Calculates a moving average value over a specified window.  The window size must be specified
/// upon creation of this object.
/// </summary>
/// <remarks>Authored by Drew Noakes, February 2005.  Use freely, though keep this message intact and
/// report any bugs to me.  I also appreciate seeing extensions, or simply hearing that you're using
/// these classes.  You may not copyright this work, though may use it in commercial/copyrighted works.
/// Happy coding.
///
/// Updated 29 March 2007.  Added a Reset() method.</remarks>
public sealed class MovingAverage {
    private readonly int windowSize;
    private readonly float[] values;
    private int index;
    private float sum;
    private int numRecorded;
    private float currentAverage;

    /// <summary>
    /// Create a new moving average calculator.
    /// </summary>
    /// <param name="windowSize">The maximum number of values to be considered
    /// by this moving average calculation.</param>
    /// <exception cref="ArgumentOutOfRangeException">If windowSize less than one.</exception>
    public MovingAverage(int windowSize) {
        if (windowSize < 1) {
            throw new ArgumentOutOfRangeException(nameof(windowSize), windowSize, "Window size must be greater than zero.");
        }

        this.windowSize = windowSize;
        values = new float[this.windowSize];

        Reset();
    }

    /// <summary>
    /// Updates the moving average with its next value, and returns the updated average value.
    /// When IsMature is true and NextValue is called, a previous value will 'fall out' of the
    /// moving average.
    /// </summary>
    /// <param name="nextValue">The next value to be considered within the moving average.</param>
    /// <returns>The updated moving average value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">If nextValue is equal to float.NaN.</exception>
    public float Record(float nextValue) {
        if (float.IsNaN(nextValue)) {
            throw new ArgumentOutOfRangeException(nameof(nextValue), "NaN may not be provided as the next value.  It would corrupt the state of the calculation.");
        }

        // add new value to the sum
        sum += nextValue;

        if (numRecorded < windowSize) {
            // we haven't yet filled our window
            numRecorded++;
        } else {
            // remove oldest value from sum
            sum -= values[index];
        }

        // store the value
        values[index] = nextValue;

        // progress the next value index pointer
        // https://embeddedgurus.com/stack-overflow/2011/02/efficient-c-tip-13-use-the-modulus-operator-with-caution/
        index++;
        if (index == windowSize) {
            index = 0;
        }

        currentAverage = sum / numRecorded;
        return currentAverage;
    }

    public float Current() {
        return currentAverage;
    }

    /// <summary>
    /// Gets a value indicating whether enough values have been provided to fill the
    /// speicified window size.  Values returned from NextValue may still be used prior
    /// to IsMature returning true, however such values are not subject to the intended
    /// smoothing effect of the moving average's window size.
    /// </summary>
    public bool IsMature {
        get { return numRecorded == windowSize; }
    }

    /// <summary>
    /// Clears any accumulated state and resets the calculator to its initial configuration.
    /// Calling this method is the equivalent of creating a new instance.
    /// </summary>
    public void Reset() {
        index = 0;
        sum = 0;
        numRecorded = 0;
        currentAverage = 0;
    }
}