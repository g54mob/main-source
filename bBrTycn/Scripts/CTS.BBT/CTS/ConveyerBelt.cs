using System;
using UnityEngine;

namespace CTS
{
	public class ConveyerBelt : MonoBehaviour
	{
		public int matI;

		[Range(0.1f, 1f)]
		public float speed;

		public bool isMove;

		private Renderer mr;

		private Material m;

		private float customTime;

		private float normalizedSpeed;

		public void Start()
		{
			if (!TryGetComponent<Renderer>(out mr))
			{
				throw new Exception(base.name + ": No Renderer found");
			}
			m = mr.materials[matI];
		}

		private void Update()
		{
			if (isMove)
			{
				customTime += Time.deltaTime;
				normalizedSpeed = 1f / speed;
				if (customTime > normalizedSpeed)
				{
					customTime -= normalizedSpeed;
				}
				m.SetFloat("_CustomTime", customTime);
			}
			m.SetFloat("_Speed", speed);
		}
	}
}
