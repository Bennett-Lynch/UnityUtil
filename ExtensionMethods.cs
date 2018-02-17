using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.Mathf;
using static UnityEngine.Vector3;

public static class ExtensionMethods {
    
    /// <summary> Reset position to 0, rotation to 0, and scale to 1. </summary>
    public static void ResetTransformation(this Transform trans) {
        trans.position = zero;
        trans.localRotation = Quaternion.identity;
        trans.localScale = one;
    }

    /// <summary> Sets the x/y/z local scales to a uniform value. </summary>
    public static void SetLocalScale(this Transform trans, float scale) {
        trans.localScale = one * scale;
    }

    /// <summary> Uses the x,y coordinates of the Vector3 to make a new Vector2. </summary>
    public static Vector2 xy(this Vector3 vector) {
        return new Vector2(vector.x, vector.y);
    }

    /// <summary> Uses the x,z coordinates of the Vector3 to make a new Vector2. </summary>
    public static Vector2 xz(this Vector3 vector) {
        return new Vector2(vector.x, vector.z);
    }

    /// <summary> Uses the y,z coordinates of the Vector3 to make a new Vector2. </summary>
    public static Vector2 yz(this Vector3 vector) {
        return new Vector2(vector.y, vector.z);
    }

    /// <summary> Converts this Vector2 into a Vector3, leaving the x and y values in-tact and using the provided parameter as the value of the new z field. </summary>
    public static Vector3 ToVector3(this Vector2 vector, float zValue = 0) {
        return new Vector3(vector.x, vector.y, zValue);
    }

    /// <summary> Sets the RGB color values using integers in the range of 0 - 255. </summary>
    public static void SetRgb256(this Color color, int red = 255, int green = 255, int blue = 255, int alpha = 255) {
        color.r = Clamp01(red / 255f);
        color.g = Clamp01(green / 255f);
        color.b = Clamp01(blue / 255f);
        color.a = Clamp01(alpha / 255f);
    }

    /// <summary>
    /// Given the desired position of the RectTransform, return its position constrained within the screen boundaries.
    /// Note that this method does not set the position of the RectTransform itself, as that could potentially introduce some unwanted jitter.
    /// </summary>
    /// <param name="rt"></param>
    /// <param name="desiredPosition">The desired, unclamped position.</param>
    /// <returns></returns>
    public static Vector3 GetScreenClampedPosition(this RectTransform rt, Vector3 desiredPosition) {
        desiredPosition.x = Clamp(desiredPosition.x, rt.pivot.x * rt.rect.width, Screen.width - (1 - rt.pivot.x) * rt.rect.width);
        desiredPosition.y = Clamp(desiredPosition.y, rt.pivot.y * rt.rect.height, Screen.height - (1 - rt.pivot.y) * rt.rect.height);
        return desiredPosition;
    }

    /// <summary>
    /// Modify the position of the transform so that it is constrained within the screen boundaries.
    /// Use "GetScreenClampedPosition" instead to return the constrained coordinates of a desired position.
    /// </summary>
    /// <param name="rt"></param>
    public static void ClampToScreen(this RectTransform rt) {
        rt.position = rt.GetScreenClampedPosition(rt.position);
    }

    // http://answers.unity3d.com/questions/37875/turning-the-particle-system-on-and-off.html
    
//    /// <summary>
//    /// Extension method to stop the ParticleSystem emission with one clean line of code.
//    /// </summary>
//    /// <param name="ps"></param>
//    public static void DisableEmission(this ParticleSystem ps) {
//        var em = ps.emission;
//        em.enabled = false;
//    }
//
//    /// <summary>
//    /// Extension method to start the ParticleSystem emission with one clean line of code.
//    /// </summary>
//    /// <param name="ps"></param>
//    public static void EnableEmission(this ParticleSystem ps) {
//        var em = ps.emission;
//        em.enabled = true;
//    }

    public static void SetDestination(this NavMeshAgent agent, Transform destination) {
        agent.SetDestination(destination.position);
    }

    public static void SetDestination(this NavMeshAgent agent, MonoBehaviour destination) {
        agent.SetDestination(destination.transform.position);
    }

    /// <summary>
    /// Force an immediate update of the new destination by calling ResetPath() and SetDestination().
    /// </summary>
    /// <param name="agent"></param>
    /// <param name="destination"></param>
    public static void ForceDestination(this NavMeshAgent agent, Vector3 destination) {
        agent.ResetPath();
        agent.SetDestination(destination);
    }

    public static void ForceDestination(this NavMeshAgent agent, Transform destination) {
        agent.ResetPath();
        agent.SetDestination(destination.position);
    }

    public static void ForceDestination(this NavMeshAgent agent, MonoBehaviour destination) {
        agent.ResetPath();
        agent.SetDestination(destination.transform.position);
    }

    /// <summary> Returns a random integer number between 0 [inclusive] and this value [exclusive] </summary>
    public static int RandomValue(this int i) {
        return Random.Range(0, i);
    }

    public static T RandomElement<T>(this T[] array) {
        int i = array.Length.RandomValue();
        return array[i];
    }

//    public static Vector3 Position(this MonoBehaviour monoBehaviour) {
//        return monoBehaviour.transform.position;
//    }
//
//    public static Vector3 Position(this GameObject gameObject) {
//        return gameObject.transform.position;
//    }
//    
//    public static Quaternion Rotation(this MonoBehaviour monoBehaviour) {
//        return monoBehaviour.transform.rotation;
//    }
//
//    public static Quaternion Rotation(this GameObject gameObject) {
//        return gameObject.transform.rotation;
//    }
}