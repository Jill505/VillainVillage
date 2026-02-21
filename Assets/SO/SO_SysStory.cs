using UnityEngine;

[CreateAssetMenu(fileName = "SO_SysStory", menuName = "Scriptable Objects/SO_SysStory")]
public class SO_SysStory : ScriptableObject
{
    [TextArea(2, 10)]
    public string[] Context;
}
