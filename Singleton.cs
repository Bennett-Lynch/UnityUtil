using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance => instance ?? (instance = FindObjectOfType<T>());
    private static T instance { get; set; }

    /// <summary>
    /// Unfortunately, FindObjectOfType only finds active objects.
    /// This method can be called if we need to deactivate a gameObject
    /// that hasn't had its singleton initialized yet.
    /// </summary>
    protected void InitializeSingleton() {
        var forcefullyInitialize = Instance;
    }
}