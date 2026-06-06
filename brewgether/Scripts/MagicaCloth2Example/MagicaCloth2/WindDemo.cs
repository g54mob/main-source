using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	public class WindDemo : MonoBehaviour
	{
		[SerializeField]
		private MagicaWindZone magicaWindZone;

		[SerializeField]
		private WindZone unityWindZone;

		[SerializeField]
		private Renderer arrowRenderer;

		[SerializeField]
		private Gradient arrowGradient;

		[SerializeField]
		private List<Transform> rotationTransforms;

		private float angleY;

		private float angleX;

		private float main;

		private float turbulence;

		public void OnDirectionY(float value)
		{
		}

		public void OnDirectionX(float value)
		{
		}

		public void OnMain(float value)
		{
		}

		public void OnTurbulence(float value)
		{
		}

		private void UpdateArrowColor()
		{
		}

		private void UpdateDirection()
		{
		}

		private void UpdateMagicaWindZone()
		{
		}

		private void UpdateUnityWindZone()
		{
		}
	}
}
