using UnityEngine;

/// <summary>
/// Convenience method overloads.
/// Think of them as static extension methods for existing classes.
/// </summary>
public class Overloads {
    #region Quaternion.LookRotation Overloads

    public static float Distance(Vector3 a, Transform b) {
        return Vector3.Distance(a, b.position);
    }

    public static float Distance(Vector3 a, MonoBehaviour b) {
        return Vector3.Distance(a, b.transform.position);
    }

    public static float Distance(Vector3 a, GameObject b) {
        return Vector3.Distance(a, b.transform.position);
    }

    public static float Distance(Transform a, Vector3 b) {
        return Vector3.Distance(a.position, b);
    }

    public static float Distance(Transform a, Transform b) {
        return Vector3.Distance(a.position, b.position);
    }

    public static float Distance(Transform a, MonoBehaviour b) {
        return Vector3.Distance(a.position, b.transform.position);
    }

    public static float Distance(Transform a, GameObject b) {
        return Vector3.Distance(a.position, b.transform.position);
    }

    public static float Distance(MonoBehaviour a, Vector3 b) {
        return Vector3.Distance(a.transform.position, b);
    }

    public static float Distance(MonoBehaviour a, Transform b) {
        return Vector3.Distance(a.transform.position, b.position);
    }

    public static float Distance(MonoBehaviour a, MonoBehaviour b) {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }

    public static float Distance(MonoBehaviour a, GameObject b) {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }

    public static float Distance(GameObject a, Vector3 b) {
        return Vector3.Distance(a.transform.position, b);
    }

    public static float Distance(GameObject a, Transform b) {
        return Vector3.Distance(a.transform.position, b.position);
    }

    public static float Distance(GameObject a, MonoBehaviour b) {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }

    public static float Distance(GameObject a, GameObject b) {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }

    #endregion

    #region Quaternion.LookRotation Overloads

    public static Quaternion Face(Vector3 from, Transform to) {
        return Quaternion.LookRotation(to.position - from);
    }

    public static Quaternion Face(Vector3 from, MonoBehaviour to) {
        return Quaternion.LookRotation(to.transform.position - from);
    }

    public static Quaternion Face(Vector3 from, GameObject to) {
        return Quaternion.LookRotation(to.transform.position - from);
    }

    public static Quaternion Face(Transform from, Vector3 to) {
        return Quaternion.LookRotation(to - from.position);
    }

    public static Quaternion Face(Transform from, Transform to) {
        return Quaternion.LookRotation(to.position - from.position);
    }

    public static Quaternion Face(Transform from, MonoBehaviour to) {
        return Quaternion.LookRotation(to.transform.position - from.position);
    }

    public static Quaternion Face(Transform from, GameObject to) {
        return Quaternion.LookRotation(to.transform.position - from.position);
    }

    public static Quaternion Face(MonoBehaviour from, Vector3 to) {
        return Quaternion.LookRotation(to - from.transform.position);
    }

    public static Quaternion Face(MonoBehaviour from, Transform to) {
        return Quaternion.LookRotation(to.position - from.transform.position);
    }

    public static Quaternion Face(MonoBehaviour from, MonoBehaviour to) {
        return Quaternion.LookRotation(to.transform.position - from.transform.position);
    }

    public static Quaternion Face(MonoBehaviour from, GameObject to) {
        return Quaternion.LookRotation(to.transform.position - from.transform.position);
    }

    public static Quaternion Face(GameObject from, Vector3 to) {
        return Quaternion.LookRotation(to - from.transform.position);
    }

    public static Quaternion Face(GameObject from, Transform to) {
        return Quaternion.LookRotation(to.position - from.transform.position);
    }

    public static Quaternion Face(GameObject from, MonoBehaviour to) {
        return Quaternion.LookRotation(to.transform.position - from.transform.position);
    }

    public static Quaternion Face(GameObject from, GameObject to) {
        return Quaternion.LookRotation(to.transform.position - from.transform.position);
    }

    #endregion

    #region Object.Instantiate Overloads

    public static T Instantiate<T>(T original, Transform destination, Quaternion rotation) where T : Object {
        return Object.Instantiate<T>(original, destination.position, rotation);
    }

    /// <summary> Use the destination as the rotation as well. </summary>
    public static T Instantiate<T>(T original, Transform destination) where T : Object {
        return Object.Instantiate<T>(original, destination.position, destination.rotation);
    }

    public static T Instantiate<T>(T original, MonoBehaviour destination, Quaternion rotation) where T : Object {
        return Object.Instantiate<T>(original, destination.transform.position, rotation);
    }

    /// <summary> Use the destination as the rotation as well. </summary>
    public static T Instantiate<T>(T original, MonoBehaviour destination) where T : Object {
        return Object.Instantiate<T>(original, destination.transform.position, destination.transform.rotation);
    }

    public static T Instantiate<T>(T original, GameObject destination, Quaternion rotation) where T : Object {
        return Object.Instantiate<T>(original, destination.transform.position, rotation);
    }

    /// <summary> Use the destination as the rotation as well. </summary>
    public static T Instantiate<T>(T original, GameObject destination) where T : Object {
        return Object.Instantiate<T>(original, destination.transform.position, destination.transform.rotation);
    }

    #endregion

    #region Physics.OverlapSphere Overloads

    public static Collider[] OverlapSphere(Transform position, float radius, int layerMask) {
        return Physics.OverlapSphere(position.position, radius, layerMask);
    }

    public static Collider[] OverlapSphere(MonoBehaviour position, float radius, int layerMask) {
        return Physics.OverlapSphere(position.transform.position, radius, layerMask);
    }

    public static Collider[] OverlapSphere(GameObject position, float radius, int layerMask) {
        return Physics.OverlapSphere(position.transform.position, radius, layerMask);
    }

    #endregion

    // TODO permutations for , overlap sphere, and ctrl+f for .transform.position or .transform.rotation
}