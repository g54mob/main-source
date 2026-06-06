using UnityEngine;

namespace Brewery.Bar.Brawl
{
	public class BrawlDebugOverlay : MonoBehaviour
	{
		[Header("Debug Display")]
		[SerializeField]
		private bool showOverlay;

		[SerializeField]
		private bool showGizmos;

		[SerializeField]
		private KeyCode toggleKey;

		[Header("Colors")]
		[SerializeField]
		private Color activeColor;

		[SerializeField]
		private Color spectatorColor;

		[SerializeField]
		private Color attackerLineColor;

		[SerializeField]
		private Color brawlRadiusColor;

		private BarBrawlManager brawlManager;

		private GUIStyle headerStyle;

		private GUIStyle labelStyle;

		private bool stylesInitialized;

		private void Update()
		{
		}

		private void OnGUI()
		{
		}

		private void InitializeStyles()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
