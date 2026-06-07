using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LitJson;
using UnityEngine;
using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.GameModifiers
{
	[InitializeOnGameStarted]
	public class GameModifierNode : StoryNode
	{
		[JsonIgnore]
		private static (GameModifierNode node, ActiveStory story)[] _activeNodesWithActiveStories;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		[Tooltip("this explanation is shown in a 'game modifier' alert badge as a tooltip")]
		[StoryNodeTranslateFieldContent("alertText", "Node")]
		public string alertText;

		public bool hideFromPlayer;

		[JsonIgnore]
		public static (GameModifierNode node, ActiveStory story)[] ActiveNodesWithActiveStories => null;

		public static event EventHandler GameModifierNodesChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public static IEnumerable<GameModifierNode> GetActiveNodes()
		{
			return null;
		}

		public virtual string GetGroupKey()
		{
			return null;
		}

		public virtual string GetAlertTextKey()
		{
			return null;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}

		private static void Changed()
		{
		}
	}
}
