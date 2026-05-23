using System;
using System.Collections;
using Data.Variables;
using Events.UI.TechTree;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Presentation.UI.TechTree
{
	public class TechTreeUIReveal : MonoBehaviour
	{
		[SerializeField]
		private NodeRevealedEvent _nodeRevealedEvent;

		[SerializeField]
		private NodeRevealedEvent _nodeRevealFinishedEvent;

		[SerializeField]
		private Material _nodeRevealedMaterial;

		[SerializeField]
		private InputActionReference _escapeActionRef;

		private static readonly int SilhouetteTime = Shader.PropertyToID("_SilhouetteTime");

		private static readonly int RevealTime = Shader.PropertyToID("_RevealTime");

		private static readonly int FinalFadeTime = Shader.PropertyToID("_FinalFadeTime");

		private static readonly int StartTime = Shader.PropertyToID("_StartTime");

		private float _silhouetteTime;

		private float _revealTime;

		private float _finalFadeTime;

		private Coroutine _revealCoroutine;

		private BoolVariableSO _revealingShowBool;

		public void CancelReveal()
		{
			if (_revealCoroutine != null)
			{
				StopCoroutine(_revealCoroutine);
			}
			_escapeActionRef.action.Enable();
			_nodeRevealFinishedEvent.Fire(new NodeRevealedData(_revealingShowBool, _nodeRevealedMaterial));
		}

		public void Reveal(float panTime, BoolVariableSO techTreeShowBool, Action onRevealComplete)
		{
			_revealingShowBool = techTreeShowBool;
			_escapeActionRef.action.Disable();
			_revealCoroutine = StartCoroutine(RevealCoroutine(panTime, techTreeShowBool, onRevealComplete));
		}

		private IEnumerator RevealCoroutine(float panTime, BoolVariableSO techTreeShowBool, Action onRevealComplete)
		{
			Material revealMat = UnityEngine.Object.Instantiate(_nodeRevealedMaterial);
			_silhouetteTime = revealMat.GetFloat(SilhouetteTime);
			_revealTime = revealMat.GetFloat(RevealTime);
			_finalFadeTime = revealMat.GetFloat(FinalFadeTime);
			revealMat.SetFloat(StartTime, float.MaxValue);
			yield return null;
			_nodeRevealedEvent.Fire(new NodeRevealedData(techTreeShowBool, revealMat));
			yield return new WaitForSeconds(panTime);
			revealMat.SetFloat(StartTime, Time.time);
			yield return new WaitForSeconds(_silhouetteTime + _revealTime + _finalFadeTime);
			_escapeActionRef.action.Enable();
			_nodeRevealFinishedEvent.Fire(new NodeRevealedData(techTreeShowBool, revealMat));
			onRevealComplete?.Invoke();
		}
	}
}
