using System.Collections.Generic;
using UnityEngine;

namespace VFXTools
{
	public class ChangeFX2 : MonoBehaviour
	{
		public List<GameObject> FX;

		private float time;

		public float waitTime = 1f;

		private void Start()
		{
			FX.ForEach(delegate(GameObject obj)
			{
				obj.SetActive(value: true);
			});
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
			FX.ForEach(delegate(GameObject obj)
			{
				obj.SetActive(value: false);
			});
			FX.ForEach(delegate(GameObject obj)
			{
				obj.SetActive(value: true);
			});
		}
	}
}
