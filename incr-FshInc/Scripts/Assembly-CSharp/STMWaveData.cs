using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Wave Data", menuName = "Super Text Mesh/Wave Data", order = 1)]
public class STMWaveData : ScriptableObject
{
	public bool animateFromTimeDrawn;

	public bool positionControl = true;

	[FormerlySerializedAs("main")]
	public STMWaveControl position;

	[Tooltip("Use these below values?")]
	public bool individualVertexControl;

	public STMWaveControl topLeft;

	public STMWaveControl topRight;

	public STMWaveControl bottomLeft;

	public STMWaveControl bottomRight;

	public bool rotationControl;

	public STMWaveRotationControl rotation;

	public bool scaleControl;

	public STMWaveScaleControl scale;
}
