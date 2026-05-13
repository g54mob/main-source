using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour
{
	[SerializeField]
	private ScrollRect scrollRect;

	public float position;

	private void Start()
	{
	}

	private void Update()
	{
		scrollRect.verticalNormalizedPosition = position;
	}
}
