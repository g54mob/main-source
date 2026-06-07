using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace VampireSurvivors.Framework.DLC
{
	public class TestDlcLoading : MonoBehaviour
	{
		[SerializeField]
		private List<AssetLabelReference> _GroupLabels;

		private long _allocatedOnBoot;

		private bool _hasLoaded;

		private void Update()
		{
		}

		private void TryLoad()
		{
		}

		private void LoadAddressableGroup()
		{
		}

		private void LogDebug(string message)
		{
		}
	}
}
