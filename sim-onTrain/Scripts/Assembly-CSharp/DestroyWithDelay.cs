using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
	[SerializeField]
	[Range(0f, 1000f)]
	private float m_Delay;

	private void Start()
	{
		Object.Destroy(base.gameObject, m_Delay);
	}
}
