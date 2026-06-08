using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Kitchen
{
	public class VFXPool : SerializedMonoBehaviour
	{
		public static VFXPool Pool;

		[SerializeField]
		private Transform ContainerA;

		[SerializeField]
		private Transform ContainerB;

		private Transform ActiveContainer;

		private void OnEnable()
		{
			Pool = this;
			StartCoroutine(UpdateContainerInUse());
		}

		private IEnumerator UpdateContainerInUse()
		{
			while (true)
			{
				ActiveContainer = ((ActiveContainer == ContainerA) ? ContainerB : ContainerA);
				try
				{
					foreach (Transform item in ActiveContainer)
					{
						UnityEngine.Object.Destroy(item.gameObject);
					}
				}
				catch (Exception message)
				{
					Debug.LogWarning(message);
				}
				yield return new WaitForSeconds(5f);
			}
		}

		public void CommitToPool(Transform container)
		{
			container.parent = ActiveContainer;
		}
	}
}
