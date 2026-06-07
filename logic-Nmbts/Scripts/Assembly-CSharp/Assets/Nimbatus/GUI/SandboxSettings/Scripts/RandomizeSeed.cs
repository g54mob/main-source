using System;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SandboxSettings.Scripts
{
	public class RandomizeSeed : MonoBehaviour
	{
		public UIInput SeedLabel;

		public void OnClick()
		{
			SeedLabel.value = Guid.NewGuid().ToString().GetHashCode()
				.ToString();
		}
	}
}
