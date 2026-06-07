using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class DisableOnStart : MonoBehaviour
	{
		private Camera _camera;

		public void Start()
		{
			_camera = GetComponent<Camera>();
			_camera.enabled = true;
			_camera.targetTexture.Release();
			StartCoroutine(CheckRenderTextures());
		}

		public IEnumerator CheckRenderTextures()
		{
			yield return new WaitForSeconds(1f);
			while (true)
			{
				yield return new WaitForSeconds(0.2f);
				if (_camera.targetTexture.IsCreated() && !RuntimeGlobals.IsGameLoading)
				{
					for (int i = 0; i < base.transform.childCount; i++)
					{
						base.transform.GetChild(i).gameObject.SetActive(false);
					}
					_camera.enabled = false;
					continue;
				}
				for (int j = 0; j < base.transform.childCount; j++)
				{
					base.transform.GetChild(j).gameObject.SetActive(true);
				}
				_camera.enabled = true;
				_camera.targetTexture.MarkRestoreExpected();
			}
		}
	}
}
