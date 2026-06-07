using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps
{
	public class TutorialStepBuilderContext
	{
		public class StepBuilder<T> where T : TutorialStep
		{
			private readonly TutorialStepBuilderContext _context;

			private readonly T _step;

			public T Step => _step;

			public StepBuilder(TutorialStepBuilderContext context, T step)
			{
				_context = context;
				_step = step;
			}

			public StepBuilder<T> Configure(Action<T> stepConfigAction)
			{
				stepConfigAction(_step);
				return this;
			}

			public StepBuilder<T> SetCameraTarget(TutorialStepCameraTarget cameraTarget)
			{
				_step.CameraTarget = cameraTarget;
				return this;
			}

			public StepBuilder<T> SetCameraTarget(string targetPartName, float rotationX, float rotationY, float distance)
			{
				int partIdByName = _context.GetPartIdByName(targetPartName);
				if (!_context.GetPartPositionAndRotation(partIdByName, out var position, out var _))
				{
					Debug.LogError("Unable to set the camera target on the tutorial step because the position of part '" + targetPartName + "' could not be found in the craft XML.");
					return this;
				}
				return SetCameraTarget(new TutorialStepCameraTarget(position, Quaternion.Euler(rotationX, rotationY, 0f), distance));
			}

			public StepBuilder<T> SetCameraTarget(string targetPartName, Vector3 offset, float rotationX, float rotationY, float distance)
			{
				int partIdByName = _context.GetPartIdByName(targetPartName);
				if (!_context.GetPartPositionAndRotation(partIdByName, out var position, out var _))
				{
					Debug.LogError("Unable to set the camera target on the tutorial step because the position of part '" + targetPartName + "' could not be found in the craft XML.");
					return this;
				}
				return SetCameraTarget(new TutorialStepCameraTarget(position + offset, Quaternion.Euler(rotationX, rotationY, 0f), distance));
			}

			public StepBuilder<T> SetCameraTarget(Vector3 position, Quaternion rotation, float distance)
			{
				return SetCameraTarget(new TutorialStepCameraTarget(position, rotation, distance));
			}

			public StepBuilder<T> SetDefaultHighlightConfiguration(Vector3? scale = null, Func<Color> colorFunc = null, bool? useZTest = null)
			{
				_step.SetDefaultHighlightConfiguration(scale, colorFunc, useZTest);
				return this;
			}
		}

		private List<TutorialStep> _steps;

		public XElement CraftXml { get; set; }

		public TutorialStep CurrentStep => _steps[_steps.Count - 1];

		public DesignerScript Designer { get; }

		public List<int> LoadedPartIds { get; set; }

		public IReadOnlyList<TutorialStep> Steps => _steps;

		public Tutorial Tutorial { get; }

		public TutorialStepBuilderContext(Tutorial tutorial, DesignerScript designer)
		{
			Tutorial = tutorial;
			Designer = designer;
			LoadedPartIds = new List<int>();
			_steps = new List<TutorialStep>();
		}

		public StepBuilder<T> AddStep<T>(T step) where T : TutorialStep
		{
			CraftXml = step.CraftXml;
			LoadedPartIds.Clear();
			LoadedPartIds.AddRange(step.LoadedPartIds);
			LoadedPartIds.AddRange(step.AddedPartIds);
			_steps.Add(step);
			return new StepBuilder<T>(this, step);
		}

		public int GetPartIdByName(string partName)
		{
			return TutorialStep.GetPartIdByName(partName, CraftXml);
		}

		public bool GetPartPositionAndRotation(int partId, out Vector3 position, out Vector3 rotation)
		{
			return TutorialStep.GetPartPositionAndRotation(partId, CraftXml, out position, out rotation);
		}

		public int GetSymmetricPartId(int partId)
		{
			return TutorialStep.GetSymmetricPartId(partId, CraftXml);
		}

		public int? GetSymmetricPartIdOrNull(int partId)
		{
			return TutorialStep.GetSymmetricPartIdOrNull(partId, CraftXml);
		}

		public void LoadAllParts(IEnumerable<string> excludedParts = null)
		{
			IEnumerable<XElement> enumerable = CraftXml?.Element("Assembly")?.Element("Parts")?.Elements("Part");
			if (enumerable == null)
			{
				return;
			}
			foreach (XElement item in enumerable)
			{
				string stringAttributeOrNullIfEmpty = item.GetStringAttributeOrNullIfEmpty("name");
				if (excludedParts == null || !excludedParts.Contains(stringAttributeOrNullIfEmpty))
				{
					int? num = (int?)item.Attribute("id");
					if (num.HasValue && !LoadedPartIds.Contains(num.Value))
					{
						LoadedPartIds.Add(num.Value);
					}
				}
			}
		}

		public void SetCraftXml(string xmlPath)
		{
			CraftXml = Game.Instance.CraftDatabase.LoadBuiltinCraftXml(xmlPath, showErrorDialogs: true);
		}
	}
}
