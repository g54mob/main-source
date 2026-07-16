using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputAssetsSO", menuName = "Input Assets SO")]
public class InputAssetsSO : ScriptableObject
{
	[field: SerializeField]
	public InputActionReference InputActionReference { get; private set; }

	[field: SerializeField]
	public Sprite InputIcon { get; private set; }

	[field: SerializeField]
	public char KeyChar { get; private set; }

	[field: SerializeField]
	public Sprite ArrowDirectionIcon { get; private set; }
}
