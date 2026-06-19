using UnityEngine;
using UnityEngine.Serialization;

public class PaintableObjectAuthoring : MonoBehaviour
{
	[FormerlySerializedAs("colorIndex")]
	public PaintableColor color;
}
