using Gh.Tk;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(MeshRenderer))]
public class IgnoreMeshRendererFor : MonoBehaviour
{
	public GameObjectX.MeshType[] MeshTypes;
}
