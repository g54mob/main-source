using DV.Utils;
using UnityEngine;

public class WindAudio : MonoBehaviour
{
	public LayeredAudio windAudio;

	private Rigidbody _rb;

	[SerializeField]
	private float dragCoeficient = 0.5f;

	[SerializeField]
	private float referenceArea = 3f;

	private const float airDensity = 1.225f;

	private Rigidbody rb
	{
		get
		{
			if (!_rb)
			{
				_rb = GetComponent<Rigidbody>();
			}
			return _rb;
		}
	}

	private void Start()
	{
		if (!windAudio && (bool)SingletonBehaviour<AudioManager>.Instance)
		{
			windAudio = AudioManager.InstantiateLayeredAudio(SingletonBehaviour<AudioManager>.Instance.windAudio, base.transform);
			windAudio.Reset();
		}
	}

	private void Update()
	{
		if (!windAudio)
		{
			base.enabled = false;
			return;
		}
		float level = dragCoeficient * referenceArea * 0.5f * 1.225f * rb.velocity.sqrMagnitude;
		windAudio.Set(level);
	}
}
