using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class DefenseStructuresTutorialStep : TutorialStep
	{
		private readonly struct PositionRotation
		{
			public readonly Vec3Int Position;

			public readonly Vector3 Rotation;

			public PositionRotation(Vec3Int position, Vector3 rotation)
			{
				Position = position;
				Rotation = rotation;
			}

			public bool Equals(Vec3Int position)
			{
				return Position.Equals(position);
			}

			public bool Equals(Vector3 rotation)
			{
				return Rotation.Equals(rotation);
			}

			public bool Equals(Vec3Int position, Vector3 rotation)
			{
				if (Position.Equals(position))
				{
					return Rotation.Equals(rotation);
				}
				return false;
			}

			[CompilerGenerated]
			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("PositionRotation");
				stringBuilder.Append(" { ");
				if (PrintMembers(stringBuilder))
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append('}');
				return stringBuilder.ToString();
			}

			[CompilerGenerated]
			private bool PrintMembers(StringBuilder builder)
			{
				builder.Append("Position = ");
				builder.Append(Position.ToString());
				builder.Append(", Rotation = ");
				builder.Append(Rotation.ToString());
				return true;
			}

			[CompilerGenerated]
			public static bool operator !=(PositionRotation left, PositionRotation right)
			{
				return !(left == right);
			}

			[CompilerGenerated]
			public static bool operator ==(PositionRotation left, PositionRotation right)
			{
				return left.Equals(right);
			}

			[CompilerGenerated]
			public override int GetHashCode()
			{
				return EqualityComparer<Vec3Int>.Default.GetHashCode(Position) * -1521134295 + EqualityComparer<Vector3>.Default.GetHashCode(Rotation);
			}

			[CompilerGenerated]
			public override bool Equals(object obj)
			{
				if (obj is PositionRotation)
				{
					return Equals((PositionRotation)obj);
				}
				return false;
			}

			[CompilerGenerated]
			public bool Equals(PositionRotation other)
			{
				if (EqualityComparer<Vec3Int>.Default.Equals(Position, other.Position))
				{
					return EqualityComparer<Vector3>.Default.Equals(Rotation, other.Rotation);
				}
				return false;
			}
		}

		private const int MerlonY = 7;

		private readonly HashSet<PositionRotation> merlonPositionRotations = new HashSet<PositionRotation>
		{
			new PositionRotation(new Vec3Int(111, 7, 111), Vector3.zero),
			new PositionRotation(new Vec3Int(111, 7, 112), Vector3.zero),
			new PositionRotation(new Vec3Int(111, 7, 113), Vector3.zero),
			new PositionRotation(new Vec3Int(112, 7, 113), new Vector3(0f, 90f, 0f)),
			new PositionRotation(new Vec3Int(113, 7, 113), new Vector3(0f, 90f, 0f)),
			new PositionRotation(new Vec3Int(114, 7, 113), new Vector3(0f, 90f, 0f)),
			new PositionRotation(new Vec3Int(114, 7, 112), new Vector3(0f, 180f, 0f)),
			new PositionRotation(new Vec3Int(114, 7, 111), new Vector3(0f, 180f, 0f)),
			new PositionRotation(new Vec3Int(114, 7, 110), new Vector3(0f, 180f, 0f)),
			new PositionRotation(new Vec3Int(114, 7, 109), new Vector3(0f, 270f, 0f)),
			new PositionRotation(new Vec3Int(113, 7, 109), new Vector3(0f, 270f, 0f)),
			new PositionRotation(new Vec3Int(112, 7, 109), new Vector3(0f, 270f, 0f)),
			new PositionRotation(new Vec3Int(111, 7, 109), new Vector3(0f, 270f, 0f))
		};

		private Vec3Int Start => new Vec3Int(112, 21, 111);

		private Vec3Int End => new Vec3Int(113, 21, 112);

		public DefenseStructuresTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_build_merlons", new object[1] { merlonPositionRotations.Count })
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			foreach (PositionRotation merlonPositionRotation in merlonPositionRotations)
			{
				MonoSingleton<TutorialViewManager>.Instance.ShowMerlonMarker(merlonPositionRotation.Position, merlonPositionRotation.Rotation);
			}
			ShowScreenPointerTarget(Start, End, Vector3.up, hideIfTargetOnscreen: true);
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI> { BuildingCategoryUI.Defense }, interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: false);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.GetCategoryTransform(BuildingCategoryUI.Defense));
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent += OnShowConstructionCategory;
			MonoSingleton<UIController>.Instance.ConstructionPanel.ClosePanelEvent += base.OnConstructionPanelClose;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI>(), interactable: true);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlaced;
		}

		public override void Tick()
		{
			base.Tick();
			CheckBuiltMerlons();
		}

		private void OnShowConstructionCategory(BuildingCategoryUI category)
		{
			if (category == BuildingCategoryUI.Defense)
			{
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "wood_merlon" }, interactable: true);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.GetSubcategoryTransform("wood_merlon"));
				});
				MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += OnChangeBuildingToPlace;
			}
		}

		private void OnChangeBuildingToPlace()
		{
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string> { "wood_merlon" }, interactable: true);
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingToPlace;
		}

		private void OnBlueprintPlaced(BaseBuildingInstance buildingInstance)
		{
			bool isEnabled;
			if (buildingInstance.BlueprintId != "wood_merlon")
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(52, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DefenseStructuresTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnBlueprintPlaced called with invalid blueprint id: ");
					messageBuilder.AppendFormatted(buildingInstance.BlueprintId);
				}
				Log.Error(messageBuilder);
				return;
			}
			Vec3Int position = buildingInstance.Positions.FirstOrDefault();
			Dictionary<BaseBuildingInstance, BaseBuildingViewComponent> dictionary = base.BuildingsManagerMain.TypeInstanceView[BuildingType.Merlon];
			if (dictionary == null || dictionary.Count == 0)
			{
				return;
			}
			BaseBuildingViewComponent baseBuildingViewComponent = dictionary[buildingInstance];
			if (baseBuildingViewComponent == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DefenseStructuresTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Couldn't find view for ");
					messageBuilder.AppendFormatted(buildingInstance);
				}
				Log.Error(messageBuilder);
			}
			_ = baseBuildingViewComponent.transform.rotation.eulerAngles;
			FVLogTraceInterpolationHandler messageBuilder2;
			foreach (PositionRotation merlonPositionRotation in merlonPositionRotations)
			{
				if (merlonPositionRotation.Equals(position))
				{
					messageBuilder2 = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DefenseStructuresTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendFormatted(position.ToString());
						messageBuilder2.AppendLiteral(" Inside Allowed");
					}
					Log.Trace(messageBuilder2);
					MonoSingleton<TutorialViewManager>.Instance.HideMerlonMarker(position);
					HideScreenPointerTarget(Start, End);
					return;
				}
			}
			messageBuilder2 = new FVLogTraceInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DefenseStructuresTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendFormatted(position.ToString());
				messageBuilder2.AppendLiteral(" Outside Allowed");
			}
			Log.Trace(messageBuilder2);
			ShowOptimizedBlackBarMessage("tutorial_wrong_construction_position");
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
			});
		}

		private void CheckBuiltMerlons()
		{
			if (Tasks[0].IsComplete)
			{
				return;
			}
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Merlon];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			float num = 0f;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value != null && IsValidPosition(item.Key) && item.Value.ConstructionPhase.Equals(ConstructionPhase.Finished))
				{
					num += 1f;
				}
			}
			float num2 = num / (float)merlonPositionRotations.Count;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DefenseStructuresTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Finished: ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(num2, "P1");
			}
			Log.Trace(messageBuilder);
			UpdateTaskCompletion(0, num2);
		}

		private bool IsValidPosition(Vec3Int position)
		{
			foreach (PositionRotation merlonPositionRotation in merlonPositionRotations)
			{
				if (merlonPositionRotation.Equals(position))
				{
					return true;
				}
			}
			return false;
		}
	}
}
