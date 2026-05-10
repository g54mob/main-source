using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class BloodyIceCrusher_VFX : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("GameObject Links")]
		public GameObject _pipeON;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		public GameObject _pipeAnim;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		public GameObject _iceBlockON;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		public GameObject _iceBlockAnim;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		public ParticleSystem _smokeVFX;

		public void EndVFXLoad()
		{
			_pipeON.SetActive(value: true);
			_iceBlockON.SetActive(value: true);
			_pipeAnim.SetActive(value: false);
			_iceBlockAnim.SetActive(value: false);
		}

		public void StartVFXUnLoadPipe()
		{
			_pipeON.SetActive(value: false);
			_pipeAnim.SetActive(value: true);
		}

		public void StartVFXUnLoadIceBlock()
		{
			_iceBlockON.SetActive(value: false);
			_iceBlockAnim.SetActive(value: true);
		}

		public void EnableSmoke()
		{
			_smokeVFX.Play();
		}

		public void DisableSmoke()
		{
			_smokeVFX.Stop();
		}
	}
}
