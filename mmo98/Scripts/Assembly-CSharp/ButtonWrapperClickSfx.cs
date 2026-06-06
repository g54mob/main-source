using UnityEngine;

[RequireComponent(typeof(ButtonWrapper))]
public class ButtonWrapperClickSfx : MonoBehaviour
{
	[SerializeField]
	private AudioDataType sfx;

	private void Awake()
	{
		GetComponent<ButtonWrapper>().onClick.AddListener(delegate
		{
			Audio.PlaySfx(sfx);
		});
	}
}
