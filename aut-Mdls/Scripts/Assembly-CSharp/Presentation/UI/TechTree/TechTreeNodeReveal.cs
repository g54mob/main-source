using System.Collections;
using System.Collections.Generic;
using Data.TechTree.Validators;
using Events.UI.TechTree;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.TechTree
{
	public class TechTreeNodeReveal : MonoBehaviour
	{
		[SerializeField]
		private List<Image> _images = new List<Image>();

		[SerializeField]
		private List<CanvasGroup> _textGroups = new List<CanvasGroup>();

		[SerializeField]
		private TechTreeNodeView _view;

		[SerializeField]
		private NodeRevealedEvent _nodeRevealedEvent;

		[SerializeField]
		private NodeRevealedEvent _nodeRevealFinishedEvent;

		[SerializeField]
		private float _revealTextFadeSpeed = 1f;

		private Coroutine _textFadeCoroutine;

		private void OnEnable()
		{
			_nodeRevealedEvent.Register(OnNodeRevealed);
			_nodeRevealFinishedEvent.Register(OnNodeRevealedFinished);
		}

		private void OnDisable()
		{
			_nodeRevealedEvent.UnRegister(OnNodeRevealed);
			_nodeRevealFinishedEvent.UnRegister(OnNodeRevealedFinished);
			foreach (Image image in _images)
			{
				image.material = null;
			}
			foreach (CanvasGroup textGroup in _textGroups)
			{
				textGroup.alpha = 1f;
			}
		}

		private void OnNodeRevealed(NodeRevealedData nodeRevealedData)
		{
			if (!NodeIsRevealed(nodeRevealedData))
			{
				return;
			}
			foreach (Image image in _images)
			{
				image.material = nodeRevealedData.RevealMat;
			}
			foreach (CanvasGroup textGroup in _textGroups)
			{
				textGroup.alpha = 0f;
			}
		}

		private bool NodeIsRevealed(NodeRevealedData nodeRevealedData)
		{
			foreach (AbstractTechTreeNodeValidator showValidator in _view.TechTreeNodeSo.ShowValidators)
			{
				if (showValidator is BoolVariableValidator boolVariableValidator && boolVariableValidator.CompareBoolVariableSO(nodeRevealedData.RevealBoolSO))
				{
					return true;
				}
			}
			return false;
		}

		private void OnNodeRevealedFinished(NodeRevealedData nodeRevealedData)
		{
			if (!NodeIsRevealed(nodeRevealedData))
			{
				return;
			}
			foreach (Image image in _images)
			{
				image.material = null;
			}
			_textFadeCoroutine = StartCoroutine(FadeInTextGroups());
		}

		private IEnumerator FadeInTextGroups()
		{
			for (float timer = 0f; timer < 1f; timer += Time.deltaTime * _revealTextFadeSpeed)
			{
				float t = Mathf.SmoothStep(0f, 1f, timer);
				foreach (CanvasGroup textGroup in _textGroups)
				{
					textGroup.alpha = Mathf.Lerp(0f, 1f, t);
				}
				yield return null;
			}
			foreach (CanvasGroup textGroup2 in _textGroups)
			{
				textGroup2.alpha = 1f;
			}
		}
	}
}
