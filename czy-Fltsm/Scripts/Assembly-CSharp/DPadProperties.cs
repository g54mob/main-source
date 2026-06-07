using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/DPad/DPad Properties")]
public class DPadProperties : ScriptableObject
{
	[SerializeField]
	private DPadButtonProperties _up;

	[SerializeField]
	private DPadButtonProperties _right;

	[SerializeField]
	private DPadButtonProperties _down;

	[SerializeField]
	private DPadButtonProperties _left;

	public DPadButtonProperties Up => _up;

	public DPadButtonProperties Right => _right;

	public DPadButtonProperties Down => _down;

	public DPadButtonProperties Left => _left;
}
