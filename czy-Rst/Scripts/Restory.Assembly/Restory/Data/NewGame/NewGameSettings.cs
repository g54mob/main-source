using System;
using System.Collections.Generic;
using Mandragora.Utils;
using Restory.Data.Equipment;
using Restory.Data.InteractiveObjects;
using Restory.Data.NPCs;
using Restory.Data.PC;
using Restory.Data.RegularPayments;
using Restory.Data.Tables.Parameters;
using Restory.Data.ToDoList;
using Restory.Data.Tutorials;
using Restory.Gameplay.Elements;
using UnityEngine;
using UnityEngine.Serialization;

namespace Restory.Data.NewGame
{
	[CreateAssetMenu(fileName = "NewGameSettings", menuName = "Restory/NewGameSettings")]
	public class NewGameSettings : ScriptableObject, IGameParametersEntity
	{
		[Serializable]
		public class ToolInitializationData
		{
			[SerializeField]
			private ToolInfo tool;

			[SerializeField]
			[Min(1f)]
			private int count = 1;

			[SerializeField]
			[Range(0f, 1f)]
			private float usesLeftPrecent = 1f;

			public ToolInfo Tool => tool;

			public int Count => count;

			public float UsesLeft
			{
				get
				{
					if (!(tool == null) && tool.IsConsumable)
					{
						return tool.MaxUses * usesLeftPrecent;
					}
					return 1f;
				}
			}
		}

		[Min(0f)]
		[SerializeField]
		private int moneyAmount;

		[Min(0f)]
		[SerializeField]
		private int tipsAmount;

		[SerializeField]
		private List<ElementData> elementsSupply = new List<ElementData>();

		[SerializeField]
		private List<InteractiveObjectInfo> personalObjects = new List<InteractiveObjectInfo>();

		[SerializeField]
		private List<ToolInitializationData> tools = new List<ToolInitializationData>();

		[SerializeField]
		private List<ToDoItem> intitToDoListItems = new List<ToDoItem>();

		[SerializeField]
		private List<RegularPaymentInfo> initialRegularPayments = new List<RegularPaymentInfo>();

		[SerializeField]
		private List<TutorialBase> initialTutorials = new List<TutorialBase>();

		[SerializeField]
		private List<PcAppInfo> initialPcApps = new List<PcAppInfo>();

		[SerializeField]
		private StoryNpcInfo firstVisitor;

		[FormerlySerializedAs("initialPalettes")]
		[SerializeField]
		private List<PaintingPaletteInfo> initialPaintingPalettes = new List<PaintingPaletteInfo>();

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool blockTimeBeforeFirstWindowOpening;

		public int InitialMoneyAmount => moneyAmount;

		public int InitialTipsAmount => tipsAmount;

		public IReadOnlyCollection<ElementData> InitialElementsSupply => elementsSupply;

		public IReadOnlyCollection<InteractiveObjectInfo> InitialPersonalObjects => personalObjects;

		public IReadOnlyCollection<ToolInitializationData> InitialTools => tools;

		public IReadOnlyCollection<ToDoItem> InitToDoListItems => intitToDoListItems;

		public IReadOnlyCollection<TutorialBase> InitialTutorials => initialTutorials;

		public IReadOnlyCollection<RegularPaymentInfo> InitialRegularPayments => initialRegularPayments;

		public IReadOnlyCollection<PaintingPaletteInfo> InitialPaintingPalettes => initialPaintingPalettes;

		public IReadOnlyCollection<PcAppInfo> InitialPcApps => initialPcApps;

		public bool BlockTimeBeforeFirstWindowOpening => blockTimeBeforeFirstWindowOpening;

		public StoryNpcInfo FirstVisitor => firstVisitor;
	}
}
