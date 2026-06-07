using System.Collections;
using System.Collections.Generic;
using Assets.Source.Util;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9AICorePuzzle : MonoBehaviour
	{
		[SerializeField]
		private T9AICoreNode _nodePrefab;

		[SerializeField]
		private Transform _nodeParent;

		[SerializeField]
		private Rect _fieldBounds;

		private List<T9AICoreNode> _nodes = new List<T9AICoreNode>();

		public T9AICoreNode ActiveNode { get; private set; }

		public bool PuzzleActive { get; private set; }

		private void OnEnable()
		{
			SetupPuzzle();
		}

		public void SetupPuzzle()
		{
			_nodes.Clear();
			_nodeParent.DestroyChildren();
			for (int i = 0; i < 8; i++)
			{
				T9AICoreNode t9AICoreNode = Object.Instantiate(_nodePrefab, _nodeParent);
				int num = 0;
				Vector3 vector;
				bool flag;
				do
				{
					num++;
					vector = new Vector3(SeededRandom.Global.RandomRange(_fieldBounds.xMin, _fieldBounds.xMax), SeededRandom.Global.RandomRange(_fieldBounds.yMin, _fieldBounds.yMax), -0.1f);
					flag = false;
					foreach (T9AICoreNode node in _nodes)
					{
						if (Vector2.Distance(node.transform.localPosition, vector) < 1.5f)
						{
							flag = true;
							break;
						}
					}
				}
				while (flag && num < 20);
				t9AICoreNode.transform.localPosition = vector;
				_nodes.Add(t9AICoreNode);
			}
			PuzzleActive = true;
		}

		public void NodeClicked(T9AICoreNode node)
		{
			if (!PuzzleActive || node == ActiveNode || (bool)node.NextNode)
			{
				return;
			}
			if ((bool)ActiveNode)
			{
				ActiveNode.LinkNodeTo(node);
			}
			UISounds.CraftStep();
			foreach (T9AICoreNode node2 in _nodes)
			{
				if ((bool)node2.NextNode && node2 != node && node2 != ActiveNode.PrevNode && node2 != ActiveNode.NextNode && GameMath.LineIntersects(ActiveNode.transform.localPosition, node.transform.localPosition, node2.transform.localPosition, node2.NextNode.transform.localPosition))
				{
					StartCoroutine(_puzzleFailed());
					return;
				}
			}
			ActiveNode = node;
			GetComponentInParent<ActiveWorldFrame>().ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			StartCoroutine(_checkPuzzleSolved());
		}

		private IEnumerator _puzzleFailed()
		{
			PuzzleActive = false;
			GetComponentInParent<ActiveWorldFrame>().ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "@T9AICoreWarning");
			ActiveNode.PuzzleFailed();
			ActiveNode = null;
			yield return new WaitForSeconds(1f);
			SetupPuzzle();
		}

		private IEnumerator _checkPuzzleSolved()
		{
			foreach (T9AICoreNode node in _nodes)
			{
				if (!node.PrevNode && !node.NextNode)
				{
					yield break;
				}
			}
			ActiveNode.PuzzleSolved();
			ActiveNode = null;
			yield return new WaitForSeconds(1f);
			SetupPuzzle();
		}
	}
}
