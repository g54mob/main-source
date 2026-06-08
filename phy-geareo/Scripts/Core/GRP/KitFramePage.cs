using System;
using System.Collections.Generic;
using GRP.Pages.NSKitFrame;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;
using UnityEngine;

namespace GRP
{
	public class KitFramePage : ProjectFramePage
	{
		[RawImageCrew]
		public StateSelector<Texture2D> stepImage;

		[ListLoaderCrew]
		public List<KitPartViewable> parts;

		[ListLoaderCrew]
		public StateSelector<List<KitStepPartViewable>> stepParts;

		[TextCrew]
		public StateSelector<string> stepText;

		[ToggleCrew]
		public State<bool> assistMode;

		[SliderCrew]
		public State<float> progress;

		[ToggleCrew]
		public State<bool> showExhibit;

		[GameObjectCrew]
		public StateSelector<bool> begin;

		public List<KitStepPartViewable> allParts;

		public State<int> stepIndex;

		public new BuildTool buildTool;

		public Action<Part> onPartCreated;

		public Kit kit;

		private Module currentModule;

		private bool currentAssistModeValue;

		private Mission mission;

		private bool lockFirstPiece;

		public KitFramePage(Kit kit, bool lockFirstPiece = false)
		{
		}

		public override void OnContextDispose()
		{
		}

		protected override void Setup()
		{
		}

		public void FetchAll()
		{
		}

		public void FetchAssist()
		{
		}

		private void OnAdded(Part createdPart)
		{
		}

		public void TogglePart(KitPart part)
		{
		}

		private void OnClick(WorldPointerEvent evt)
		{
		}

		[CrewMethod]
		public void Begin()
		{
		}

		public void Next()
		{
		}

		public void Previous()
		{
		}

		[CrewMethod]
		public void Reload()
		{
		}
	}
}
