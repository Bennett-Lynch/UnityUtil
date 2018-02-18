using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Time;
using static UnityEngine.Vector3;
// ReSharper disable MemberCanBePrivate.Global

public static class Util {
    /// <summary> Used to instantiate objects off-screen (before they can be repositioned). </summary>
    public static Vector2 OffScreen = new Vector2(-Screen.width, -Screen.height);
    
    public static T InstantiateOffScreen<T>(T original) where T : MonoBehaviour {
        return Object.Instantiate<T>(original, OffScreen, original.transform.rotation);
    }

    /// <summary> Treating this float as the starting time: how much time has elapsed since then. </summary>
    public static float TimeElapsedSince(float startTime) {
        return time - startTime;
    }

    public static float? TimeElapsedSince(float? startTime) {
        return time - startTime;
    }

    /// <summary> Treating this float as the destination time: how much time until we reach it? </summary>
    public static float TimeUntil(float endTime) {
        return endTime - time;
    }

    public static float? TimeUntil(float? endTime) {
        return endTime - time;
    }

    /// <summary> Treating this float as the starting time: what is the time difference between the end time given as the parameter (result may be negative). </summary>
    public static float TimeDifference(float startTime, float endTime) {
        return endTime - startTime;
    }

    /// <summary> Returns the *absolute* time difference between two timestamps (never negative). </summary>
    public static float AbsTimeDifference(float time1, float time2) {
        return Abs(TimeDifference(time1, time2));
    }

    /// <summary> Determine how many horizontal degrees are between where the primary transform is currently facing and the given position. y-values are ignored for this calculation. </summary>
    public static float HorizontalAngleBetween(Transform primary, MonoBehaviour target) {
        Vector3 position = target.transform.position;
        position.y = primary.position.y;
        return Angle(primary.forward, position - primary.position);
    }
}