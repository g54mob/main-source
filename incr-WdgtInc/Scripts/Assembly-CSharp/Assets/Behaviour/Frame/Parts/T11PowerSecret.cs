using System.Collections;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T11PowerSecret : MonoBehaviour
	{
		[SerializeField]
		private Transform _spinner;

		[SerializeField]
		private FrameGizmoShaker _shaker;

		[SerializeField]
		private SecretButton _button;

		public void TriggerSecret()
		{
			UISounds.CraftFinished();
			StartCoroutine(_secret());
		}

		private IEnumerator _secret()
		{
			_shaker.ForceActive = true;
			_button.gameObject.SetActive(value: true);
			yield return new WaitForSeconds(2f);
			float progress = 0f;
			while (progress < 8f)
			{
				progress += Time.deltaTime;
				_spinner.transform.position += new Vector3(Mathf.Sin(progress) * 5f * Time.deltaTime, Mathf.Cos(progress) * 5f * Time.deltaTime + Time.deltaTime * 3f);
				yield return null;
			}
		}
	}
}
