using System.Collections.Generic;
using UnityEngine;

namespace VFXTools
{
	public class ChangeFX : MonoBehaviour
	{
		public List<GameObject> FX;

		private float time;

		public float waitTime = 5f;

		private void Start()
		{
			FX.ForEach(delegate(GameObject obj)
			{
				obj.SetActive(value: false);
			});
			FX[0].SetActive(value: true);
		}

		private void Update()
		{
			if (Input.GetKeyUp(KeyCode.Tab))
			{
				DoChangeFX();
			}
			else if (time < waitTime)
			{
				time += Time.deltaTime;
			}
			else if (time >= waitTime)
			{
				DoChangeFX();
			}
		}

		private void DoChangeFX()
		{
			time = 0f;
			int num = FX.FindIndex((GameObject obj) => obj.activeSelf);
			if (num < FX.Count - 1)
			{
				FX[num].SetActive(value: false);
				FX[num + 1].SetActive(value: true);
			}
			else
			{
				FX[num].SetActive(value: false);
				FX[0].SetActive(value: true);
			}
		}
	}
}
