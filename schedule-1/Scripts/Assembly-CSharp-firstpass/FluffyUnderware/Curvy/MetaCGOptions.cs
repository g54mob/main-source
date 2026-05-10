using System;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	[HelpURL("https://curvyeditor.com/doclink/metacgoptions")]
	public class MetaCGOptions : CurvyMetadataBase
	{
		[Positive]
		[SerializeField]
		private int m_MaterialID;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private bool m_HardEdge;

		[SerializeField]
		[Positive(Tooltip = "Max step distance when using optimization")]
		private float m_MaxStepDistance;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		[Section("Extended UV", true, false, 100, HelpURL = "https://curvyeditor.com/doclink/metacgoptions_extendeduv")]
		private bool m_UVEdge;

		[Positive]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[SerializeField]
		private bool m_ExplicitU;

		[SerializeField]
		[Positive]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[FieldAction("CBSetFirstU", ActionAttribute.ActionEnum.Callback)]
		private float m_FirstU;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Positive]
		[SerializeField]
		private float m_SecondU;

		[SerializeField]
		[HideInInspector]
		private bool uVEdgeUpdated;

		private const int DefaultMaterialId = 0;

		public int MaterialID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool HardEdge
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CorrectedHardEdge => false;

		public bool UVEdge
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CorrectedUVEdge => false;

		public bool ExplicitU
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float FirstU
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SecondU
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxStepDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool HasDifferentMaterial => false;

		private bool ShowUvEdgeOrHardEdge => false;

		private bool showExplicitU => false;

		private bool showFirstU => false;

		private bool showSecondU => false;

		protected override void OnValidate()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void Awake()
		{
		}

		[UsedImplicitly]
		[Obsolete("Use ResetProperties instead")]
		public new void Reset()
		{
		}

		public float GetDefinedFirstU(float defaultValue)
		{
			return 0f;
		}

		public float GetDefinedSecondU(float defaultValue)
		{
			return 0f;
		}

		public void ResetProperties()
		{
		}

		private void EnsureUVEdgeUpdate()
		{
		}

		private bool CanHaveUvEdgeOrHadrdEdge()
		{
			return false;
		}
	}
}
