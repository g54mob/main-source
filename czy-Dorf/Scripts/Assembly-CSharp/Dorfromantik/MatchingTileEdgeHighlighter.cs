using System.Collections.Generic;
using DG.Tweening;
using Dorfromantik.UI;
using TMPro;
using UnityEngine;

namespace Dorfromantik
{
	public class MatchingTileEdgeHighlighter : MonoBehaviour
	{
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			public MatchingTileEdgeHighlighter _003C_003E4__this;

			public int edgeIndex;

			public TileEdgeState targetState;

			internal void _003CHighlightEdge_003Eb__0()
			{
				_003C_003E4__this.edgeShines[edgeIndex].gameObject.SetActive(targetState == TileEdgeState.Perfect);
			}
		}

		[SerializeField]
		private List<Transform> edgeHighlighters;

		[SerializeField]
		private List<Transform> edgeShines;

		[SerializeField]
		private List<TextMeshPro> edgeScores;

		[SerializeField]
		private float animationDuration = 0.5f;

		[SerializeField]
		private Material standardMaterial;

		[SerializeField]
		private Material perfectMaterial;

		[SerializeField]
		private Material imperfectMaterial;

		[SerializeField]
		private UiScalingManager uiScalingManager;

		private Tile tile;

		private bool displayingEdgeScores;

		private void Start()
		{
			for (int i = 0; i < 6; i++)
			{
				HighlightEdge(i, TileEdgeState.Undefined, animate: false);
			}
		}

		public void HighlightEdge(int edgeIndex, TileEdgeState targetState, bool animate = true)
		{
			_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass11_0();
			CS_0024_003C_003E8__locals17._003C_003E4__this = this;
			CS_0024_003C_003E8__locals17.edgeIndex = edgeIndex;
			CS_0024_003C_003E8__locals17.targetState = targetState;
			edgeHighlighters[CS_0024_003C_003E8__locals17.edgeIndex].gameObject.SetActive(CS_0024_003C_003E8__locals17.targetState != TileEdgeState.Undefined);
			edgeHighlighters[CS_0024_003C_003E8__locals17.edgeIndex].GetComponentInChildren<Renderer>().sharedMaterial = ((CS_0024_003C_003E8__locals17.targetState == TileEdgeState.Imperfect) ? imperfectMaterial : standardMaterial);
			ShortcutExtensions.DOKill(edgeShines[CS_0024_003C_003E8__locals17.edgeIndex]);
			if (CS_0024_003C_003E8__locals17.targetState == TileEdgeState.Perfect)
			{
				edgeShines[CS_0024_003C_003E8__locals17.edgeIndex].gameObject.SetActive(value: true);
			}
			TweenSettingsExtensions.OnComplete(ShortcutExtensions.DOScaleY(edgeShines[CS_0024_003C_003E8__locals17.edgeIndex], (CS_0024_003C_003E8__locals17.targetState == TileEdgeState.Perfect) ? 1 : 0, animate ? animationDuration : 0f), delegate
			{
				CS_0024_003C_003E8__locals17._003C_003E4__this.edgeShines[CS_0024_003C_003E8__locals17.edgeIndex].gameObject.SetActive(CS_0024_003C_003E8__locals17.targetState == TileEdgeState.Perfect);
			});
			ShortcutExtensions.DOScale(edgeScores[CS_0024_003C_003E8__locals17.edgeIndex].transform, (CS_0024_003C_003E8__locals17.targetState == TileEdgeState.Perfect && displayingEdgeScores) ? uiScalingManager.CurrentUiScalingLevel.scalingValue : 0f, animate ? animationDuration : 0f);
		}

		public void MarkPerfect(bool isPerfect)
		{
			foreach (Transform edgeHighlighter in edgeHighlighters)
			{
				edgeHighlighter.GetComponentInChildren<Renderer>().sharedMaterial = (isPerfect ? perfectMaterial : standardMaterial);
			}
		}

		public void ShowEdgeScore(bool displayEdgeScore)
		{
			displayingEdgeScores = displayEdgeScore;
		}
	}
}
