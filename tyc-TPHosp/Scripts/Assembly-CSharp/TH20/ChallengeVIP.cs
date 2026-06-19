#define LOG_LEVEL_VERBOSE
using System;
using UnityEngine;

namespace TH20
{
	public class ChallengeVIP : Challenge, IVisitorSpawned
	{
		private Visitor _vipVisitor;

		public Visitor VIP => _vipVisitor;

		public string VIPName { get; private set; }

		public Sprite VIPIcon { get; private set; }

		public ChallengeVIP(ChallengeConfig config, Level level)
			: base(config, level)
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnVisitorLeftHospital = (Action<Visitor>)Delegate.Combine(characterEvents.OnVisitorLeftHospital, new Action<Visitor>(OnVisitorLeftHospital));
		}

		public override void RestoreFromSave()
		{
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnVisitorLeftHospital = (Action<Visitor>)Delegate.Combine(characterEvents.OnVisitorLeftHospital, new Action<Visitor>(OnVisitorLeftHospital));
			base.RestoreFromSave();
		}

		public override void Destroy()
		{
			_vipVisitor = null;
			CharacterEvents characterEvents = base.Level.CharacterEvents;
			characterEvents.OnVisitorLeftHospital = (Action<Visitor>)Delegate.Remove(characterEvents.OnVisitorLeftHospital, new Action<Visitor>(OnVisitorLeftHospital));
			base.Destroy();
		}

		protected override void OnChallengeStarted()
		{
			base.OnChallengeStarted();
			VIPChallengeConfig config = GetConfig<VIPChallengeConfig>();
			ArrivalMethodDefinition arrivalMethod = ((config.ArrivalMethod == null) ? null : config.ArrivalMethod.Instance);
			base.Level.CharacterManager.SpawnVisitor(config.VisitorDef.Instance, arrivalMethod, this);
		}

		protected override int CalculateChallengeScore()
		{
			if (_vipVisitor != null)
			{
				VIPComponent component = _vipVisitor.GetComponent<VIPComponent>();
				if (component != null)
				{
					return (int)component.Appraisal.CalculateCurrentScore();
				}
			}
			return 0;
		}

		private void OnVisitorLeftHospital(Visitor visitor)
		{
			if (visitor == _vipVisitor)
			{
				FinishChallenge();
				_vipVisitor = null;
			}
		}

		protected override void OnChallengeFinished()
		{
			if (base.CompletionResult != CompletionType.Invalid)
			{
				bool flag = CalculateChallengeScore() >= _definition.RewardSuccessScore;
				base.CompletionResult = (flag ? CompletionType.Successful : CompletionType.Failed);
				if (base.CompletionResult != CompletionType.Abandoned)
				{
					base.Level.ChallengeEvents.OnChallengeVIPCompleted.InvokeSafe(this);
				}
			}
			base.OnChallengeFinished();
		}

		public override string PrintChallengeScoreBreakdown()
		{
			if (_vipVisitor == null)
			{
				return "ERROR: Cannot find VIP.";
			}
			VIPComponent component = _vipVisitor.GetComponent<VIPComponent>();
			if (component == null)
			{
				return "ERROR: Cannot find VIP Component.";
			}
			if (component.Appraisal == null)
			{
				return "ERROR: Cannot find VIPAppraisal instance on VIP Component.";
			}
			return component.Appraisal.PrintCurrentAppraisalBreakdown();
		}

		public void OnVisitorSpawned(Visitor visitor)
		{
			VIPChallengeConfig config = GetConfig<VIPChallengeConfig>();
			VIPComponent component = visitor.GetComponent<VIPComponent>();
			if (component == null)
			{
				Logging.Error("RB: We have VIP Challenge, but the visitor created does not have a VIPComponent!  They need one to calculate their route round the hospital.");
				return;
			}
			component.Initialise(base.Level, config.TourRouteConfig, config.AppraisalRangesConfig.Instance, config.AppraisalCriteriaInterest);
			_vipVisitor = visitor;
			VIPName = _vipVisitor.Name;
			VIPIcon = _vipVisitor.Definition._icon;
		}

		public void OnFailedToSpawn()
		{
			Abandon();
		}

		public bool IsValid()
		{
			if (!HasBeenDestroyed())
			{
				return base.Level.LevelScriptManager.ActiveObjectives.Contains(this);
			}
			return false;
		}

		public override bool ShowGUIOnDiscover()
		{
			return true;
		}

		public override void OnMouseSelect()
		{
			if (_vipVisitor != null)
			{
				base.Level.CameraLogic.TrackObject(_vipVisitor.GetCameraTrackObject().transform);
			}
		}
	}
}
