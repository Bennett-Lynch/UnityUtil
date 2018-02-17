using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    public static T Instance => instance ?? (instance = FindObjectOfType<T>());
    private static T instance { get; set; }
}