using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EngineCore
{
	[RequireComponent(typeof(GlowfishGlobalFog))]
	public class FogController : MonoBehaviour
	{
		protected GlowfishGlobalFog _linkedGlobalFog;

		protected int _currentPriority = -1;

		protected List<PendingFogTarget> _pendingFogTargets = new List<PendingFogTarget>();

		private int _pendingFTWildCardCounter = 3;

		protected static FogTarget _defaultSceneFogSourceTarget;

		protected static bool _defaultFogkeepFogTransitionActive;

		protected static bool _defaultFogkeepFogUpdateActiveAfterBlend;

		protected static bool _defaultFogSetsFlags;

		protected FogTarget _targetFogTarget;

		protected GlobalFogDefinition _previousDefinition = new GlobalFogDefinition();

		protected GlobalFogDefinition _currentFogTargetDefinition = new GlobalFogDefinition();

		protected bool _keepFogTransitionActive;

		protected bool _keepFogUpdateActiveAfterBlend;

		protected bool _setFlags;

		protected FogTargetTransitionParams _currentTransistionParams = new FogTargetTransitionParams(5f);

		protected bool _defaultSceneFogActive;

		protected GlobalFogDefinition _cachedDefaultSceneFogFallback = new GlobalFogDefinition();

		public FogTarget CurrentFogTarget => _targetFogTarget;

		private void Awake()
		{
			_linkedGlobalFog = GetComponent<GlowfishGlobalFog>();
			if (_defaultSceneFogSourceTarget == null)
			{
				_defaultFogkeepFogTransitionActive = false;
				_defaultFogkeepFogUpdateActiveAfterBlend = false;
				_defaultFogSetsFlags = false;
			}
		}

		private void Start()
		{
			if (_defaultSceneFogSourceTarget != null)
			{
				SetFogTarget(null, null, forced: true);
				return;
			}
			_cachedDefaultSceneFogFallback.CopyFrom(_linkedGlobalFog.CurrentFogDefinition);
			SetFogTarget(null, null, forced: true);
		}

		public static void SetDefaultSceneFog(FogTarget sourceTarget, FogTargetTransitionParams defaultFogUpdateTransistionParams = null, bool keepTransitionActive = false, bool keepFogUpdateActiveAfterBlend = false, bool setFlags = false)
		{
			if ((bool)sourceTarget)
			{
				_defaultSceneFogSourceTarget = sourceTarget;
				_defaultFogkeepFogTransitionActive = keepTransitionActive;
				_defaultFogkeepFogUpdateActiveAfterBlend = keepFogUpdateActiveAfterBlend;
				_defaultFogSetsFlags = setFlags;
				Debug.LogWarning("SetDefaultSceneFog on FogController has not been implemented for this game!!! Please implement correctly if you want to use this feature!");
			}
			else
			{
				Debug.LogWarning("Attempting to set the DefaultSceneFog but no target has been specified!! Ignoring");
			}
		}

		public void RefreshDefaultFog(FogTargetTransitionParams transistionParams)
		{
			if ((bool)_defaultSceneFogSourceTarget)
			{
				_cachedDefaultSceneFogFallback.CopyFrom(_defaultSceneFogSourceTarget.GetCurrentFogDefinition());
			}
			if (_defaultSceneFogActive)
			{
				if (transistionParams == null)
				{
					transistionParams = new FogTargetTransitionParams(0f);
				}
				_keepFogTransitionActive = _defaultFogkeepFogTransitionActive;
				_keepFogUpdateActiveAfterBlend = _defaultFogkeepFogUpdateActiveAfterBlend;
				_setFlags = _defaultFogSetsFlags;
				_defaultSceneFogActive = true;
				StopAllCoroutines();
				_targetFogTarget = _defaultSceneFogSourceTarget;
				_previousDefinition.CopyFrom(_linkedGlobalFog.CurrentFogDefinition);
				_currentFogTargetDefinition.CopyFrom(_cachedDefaultSceneFogFallback);
				_currentTransistionParams.CopyFrom(transistionParams);
				StartCoroutine("BlendFog");
			}
		}

		public void ActivatePendingFogTargetWildCard()
		{
			_pendingFTWildCardCounter = 3;
		}

		private void LateUpdate()
		{
			ProcessPendingFTList();
		}

		private void ProcessPendingFTList()
		{
			PendingFogTarget pendingFogTarget = null;
			int num = -1;
			if (_pendingFogTargets.Count > 0)
			{
				foreach (PendingFogTarget pendingFogTarget2 in _pendingFogTargets)
				{
					if (pendingFogTarget2.Priority >= num)
					{
						pendingFogTarget = pendingFogTarget2;
						num = pendingFogTarget2.Priority;
					}
				}
				SetFogTarget(pendingFogTarget.TargetFogTarget, pendingFogTarget.TransitionParams, _pendingFTWildCardCounter > 0, 0, pendingFogTarget.KeepTransitionActive, pendingFogTarget.KeepFogUpdateActiveAfterBlend, pendingFogTarget.SetFlags);
			}
			_pendingFogTargets.Clear();
			if (_pendingFTWildCardCounter > 0)
			{
				_pendingFTWildCardCounter--;
			}
		}

		public void SetFogTargetPending(FogTarget targetFogTarget, FogTargetTransitionParams transistionParams, int priority = -1, bool keepTransitionActive = false, bool keepFogUpdateActiveAfterBlend = false, bool setFlags = false)
		{
			PendingFogTarget fogTargetPending = new PendingFogTarget(targetFogTarget, transistionParams, priority, keepTransitionActive, keepFogUpdateActiveAfterBlend, setFlags);
			SetFogTargetPending(fogTargetPending);
		}

		public void SetFogTargetPending(PendingFogTarget newPendingTarget)
		{
			_pendingFogTargets.Add(newPendingTarget);
		}

		public void SetFogTarget(FogTarget targetFogTarget, FogTargetTransitionParams transistionParams, bool forced = false, int priority = -1, bool keepTransitionActive = false, bool keepFogUpdateActiveAfterBlend = false, bool setFlags = false)
		{
			if (priority > -1)
			{
				if (priority < _currentPriority)
				{
					return;
				}
				_currentPriority = priority;
			}
			_currentPriority = priority;
			GlobalFogDefinition globalFogDefinition = null;
			if (targetFogTarget == null || targetFogTarget.GetCurrentFogDefinition() == null)
			{
				targetFogTarget = _defaultSceneFogSourceTarget;
				if ((bool)targetFogTarget)
				{
					_cachedDefaultSceneFogFallback.CopyFrom(targetFogTarget.GetCurrentFogDefinition());
				}
				globalFogDefinition = _cachedDefaultSceneFogFallback;
				if (globalFogDefinition == null)
				{
					return;
				}
				_keepFogTransitionActive = _defaultFogkeepFogTransitionActive;
				_keepFogUpdateActiveAfterBlend = _defaultFogkeepFogUpdateActiveAfterBlend;
				_setFlags = _defaultFogSetsFlags;
				_defaultSceneFogActive = true;
			}
			else
			{
				globalFogDefinition = targetFogTarget.GetCurrentFogDefinition();
				_keepFogTransitionActive = keepFogUpdateActiveAfterBlend;
				_keepFogUpdateActiveAfterBlend = keepFogUpdateActiveAfterBlend;
				_setFlags = setFlags;
				_defaultSceneFogActive = false;
			}
			if (transistionParams == null)
			{
				transistionParams = new FogTargetTransitionParams(0f);
			}
			if (forced)
			{
				StopAllCoroutines();
				_targetFogTarget = targetFogTarget;
				_previousDefinition.CopyFrom(_linkedGlobalFog.CurrentFogDefinition);
				_currentFogTargetDefinition.CopyFrom(globalFogDefinition);
				if (_keepFogTransitionActive || _keepFogUpdateActiveAfterBlend)
				{
					_currentTransistionParams.CopyFrom(transistionParams);
					_currentTransistionParams.BlendTime = 0f;
					StartCoroutine("BlendFog");
				}
				else
				{
					_linkedGlobalFog.CurrentFogDefinition.CopyFrom(_currentFogTargetDefinition, _setFlags);
				}
			}
			else if (!(targetFogTarget == _targetFogTarget))
			{
				StopAllCoroutines();
				_targetFogTarget = targetFogTarget;
				_previousDefinition.CopyFrom(_linkedGlobalFog.CurrentFogDefinition);
				_currentFogTargetDefinition.CopyFrom(globalFogDefinition);
				_currentTransistionParams.CopyFrom(transistionParams);
				StartCoroutine("BlendFog");
			}
		}

		private IEnumerator BlendFog()
		{
			float currentBlendPercentage = 0f;
			float currentRemainingBlendTime = _currentTransistionParams.BlendTime;
			while (currentBlendPercentage < 1f || _keepFogTransitionActive)
			{
				if (_targetFogTarget != null && _targetFogTarget.GetCurrentFogDefinition() != null)
				{
					_currentFogTargetDefinition.CopyFrom(_targetFogTarget.GetCurrentFogDefinition());
					if (_defaultSceneFogActive)
					{
						_cachedDefaultSceneFogFallback.CopyFrom(_currentFogTargetDefinition);
					}
				}
				currentRemainingBlendTime -= Time.deltaTime;
				if (currentRemainingBlendTime > 0f && _currentFogTargetDefinition != null)
				{
					float num = (_currentTransistionParams.BlendTime - currentRemainingBlendTime) / _currentTransistionParams.BlendTime;
					float value = 0f;
					switch (_currentTransistionParams.TransitionMode)
					{
					case EFogTargetTransitionMode.Linear:
						value = Mathf.Lerp(0f, 1f, num);
						break;
					case EFogTargetTransitionMode.EaseIn:
						value = Mathf.Lerp(0f, 1f, Mathf.Pow(num, _currentTransistionParams.TransitionBlendExponent));
						break;
					case EFogTargetTransitionMode.EaseOut:
						value = Mathf.Lerp(0f, 1f, Mathf.Pow(num, 1f / _currentTransistionParams.TransitionBlendExponent));
						break;
					case EFogTargetTransitionMode.Curve:
						value = Mathf.Lerp(0f, 1f, _currentTransistionParams.TransitionCurve.Evaluate(num));
						break;
					}
					currentBlendPercentage = Mathf.Clamp01(value);
				}
				else
				{
					currentBlendPercentage = 1f;
				}
				currentBlendPercentage = Mathf.Clamp(currentBlendPercentage, 0f, 1f);
				_linkedGlobalFog.CurrentFogDefinition.BlendTo(_currentFogTargetDefinition, currentBlendPercentage, _setFlags, _previousDefinition);
				yield return null;
			}
			while (currentBlendPercentage >= 1f && _keepFogUpdateActiveAfterBlend && _currentFogTargetDefinition != null)
			{
				if (_targetFogTarget != null && _targetFogTarget.GetCurrentFogDefinition() != null)
				{
					_currentFogTargetDefinition.CopyFrom(_targetFogTarget.GetCurrentFogDefinition());
					if (_defaultSceneFogActive)
					{
						_cachedDefaultSceneFogFallback.CopyFrom(_currentFogTargetDefinition);
					}
				}
				_linkedGlobalFog.CurrentFogDefinition.CopyFrom(_currentFogTargetDefinition, _setFlags);
				yield return null;
			}
		}
	}
}
