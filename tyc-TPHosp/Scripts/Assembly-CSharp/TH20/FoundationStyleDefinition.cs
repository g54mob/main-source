using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class FoundationStyleDefinition
	{
		[Serializable]
		public struct GlobalStyle
		{
			[InspectorMargin(8)]
			public Color FoundationTextColour;

			public Color FoundationLeagueTableColour;
		}

		[Serializable]
		public struct StyleState
		{
			[InspectorMargin(8)]
			[InspectorHeader("Route")]
			public Material RouteMaterial;

			public float RouteLineThickness;

			[InspectorMargin(8)]
			[InspectorHeader("Ambulance Outline")]
			public bool AmbulanceOutlineVisible;

			[InspectorShowIf("AmbulanceOutlineVisible")]
			public Color AmbulanceOutlineColour;
		}

		[InspectorDivider]
		[InspectorMargin(8)]
		[SerializeField]
		private GlobalStyle _globalStyle;

		[InspectorDivider]
		[InspectorMargin(8)]
		[SerializeField]
		private StyleState _emphasisedStyle;

		[InspectorDivider]
		[InspectorMargin(8)]
		[SerializeField]
		private StyleState _neutralStyle;

		public GlobalStyle GlobalStyleProperties => _globalStyle;

		public StyleState GetStyle(ERenderState renderState, out ERenderState currentstate)
		{
			switch (renderState)
			{
			case ERenderState.Neutral:
				currentstate = ERenderState.Neutral;
				return _neutralStyle;
			case ERenderState.Emphasised:
				currentstate = ERenderState.Emphasised;
				return _emphasisedStyle;
			default:
				currentstate = ERenderState.Neutral;
				return _neutralStyle;
			}
		}

		public StyleState GetStyle(ERenderState renderState)
		{
			return renderState switch
			{
				ERenderState.Neutral => _neutralStyle, 
				ERenderState.Emphasised => _emphasisedStyle, 
				_ => _neutralStyle, 
			};
		}
	}
}
