using System;
using System.Collections.Generic;
using TMPEffects.Components.Animator;
using TMPEffects.TMPAnimations;
using UnityEngine;

namespace TMPEffects.Databases.AnimationDatabase
{
	[CreateAssetMenu(fileName = "new TMPAnimationDatabase", menuName = "TMPEffects/Database/Animation Database", order = 0)]
	public class TMPAnimationDatabase : TMPEffectDatabase<ITMPAnimation>
	{
		[SerializeField]
		private TMPBasicAnimationDatabase basicAnimationDatabase;

		[SerializeField]
		private TMPShowAnimationDatabase showAnimationDatabase;

		[SerializeField]
		private TMPHideAnimationDatabase hideAnimationDatabase;

		[SerializeField]
		[HideInInspector]
		private TMPBasicAnimationDatabase prevBasicAnimationDatabase;

		[SerializeField]
		[HideInInspector]
		private TMPShowAnimationDatabase prevShowAnimationDatabase;

		[SerializeField]
		[HideInInspector]
		private TMPHideAnimationDatabase prevHideAnimationDatabase;

		public TMPBasicAnimationDatabase BasicAnimationDatabase => basicAnimationDatabase;

		public TMPShowAnimationDatabase ShowAnimationDatabase => showAnimationDatabase;

		public TMPHideAnimationDatabase HideAnimationDatabase => hideAnimationDatabase;

		public bool ContainsEffect(string name, TMPAnimationType type)
		{
			return ((ITMPEffectDatabase)(type switch
			{
				TMPAnimationType.Basic => basicAnimationDatabase, 
				TMPAnimationType.Show => showAnimationDatabase, 
				TMPAnimationType.Hide => hideAnimationDatabase, 
				_ => throw new ArgumentException("type"), 
			}))?.ContainsEffect(name) ?? false;
		}

		public override bool ContainsEffect(string name)
		{
			if (basicAnimationDatabase != null && basicAnimationDatabase.ContainsEffect(name))
			{
				return true;
			}
			if (showAnimationDatabase != null && showAnimationDatabase.ContainsEffect(name))
			{
				return true;
			}
			if (hideAnimationDatabase != null && hideAnimationDatabase.ContainsEffect(name))
			{
				return true;
			}
			return false;
		}

		public ITMPAnimation GetEffect(string name, TMPAnimationType type)
		{
			return ((ITMPEffectDatabase<ITMPAnimation>)(type switch
			{
				TMPAnimationType.Basic => basicAnimationDatabase, 
				TMPAnimationType.Show => showAnimationDatabase, 
				TMPAnimationType.Hide => hideAnimationDatabase, 
				_ => throw new ArgumentException("type"), 
			}))?.GetEffect(name);
		}

		public override ITMPAnimation GetEffect(string name)
		{
			if (basicAnimationDatabase != null && basicAnimationDatabase.ContainsEffect(name))
			{
				return basicAnimationDatabase.GetEffect(name);
			}
			if (showAnimationDatabase != null && showAnimationDatabase.ContainsEffect(name))
			{
				return showAnimationDatabase.GetEffect(name);
			}
			if (hideAnimationDatabase != null && hideAnimationDatabase.ContainsEffect(name))
			{
				return hideAnimationDatabase.GetEffect(name);
			}
			throw new KeyNotFoundException();
		}

		protected override void OnValidate()
		{
			if (prevBasicAnimationDatabase != basicAnimationDatabase)
			{
				if (prevBasicAnimationDatabase != null)
				{
					prevBasicAnimationDatabase.ObjectChanged -= OnChanged;
				}
				if (basicAnimationDatabase != null)
				{
					basicAnimationDatabase.ObjectChanged += OnChanged;
				}
				prevBasicAnimationDatabase = basicAnimationDatabase;
			}
			if (prevShowAnimationDatabase != showAnimationDatabase)
			{
				if (prevShowAnimationDatabase != null)
				{
					prevShowAnimationDatabase.ObjectChanged -= OnChanged;
				}
				if (showAnimationDatabase != null)
				{
					showAnimationDatabase.ObjectChanged += OnChanged;
				}
				prevShowAnimationDatabase = showAnimationDatabase;
			}
			if (prevHideAnimationDatabase != hideAnimationDatabase)
			{
				if (prevHideAnimationDatabase != null)
				{
					prevHideAnimationDatabase.ObjectChanged -= OnChanged;
				}
				if (hideAnimationDatabase != null)
				{
					hideAnimationDatabase.ObjectChanged += OnChanged;
				}
				prevHideAnimationDatabase = hideAnimationDatabase;
			}
			RaiseDatabaseChanged();
		}

		private void OnChanged(object sender)
		{
			RaiseDatabaseChanged();
		}
	}
}
