using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Dorfromantik
{
	public class ElementFrequencyAnalyzer : MonoBehaviour
	{
		private sealed class _003CAnalyzeGeneratedTiles_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ElementFrequencyAnalyzer _003C_003E4__this;

			public float questTileProbability;

			public float delay;

			public int generatedTileCount;

			private int _003Ci_003E5__2;

			private Tile _003CnewTile_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CAnalyzeGeneratedTiles_003Ed__9(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				ElementFrequencyAnalyzer elementFrequencyAnalyzer = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003Ci_003E5__2 = 0;
					break;
				case 1:
					_003C_003E1__state = -1;
					UnityEngine.Object.Destroy(_003CnewTile_003E5__3.gameObject);
					_003CnewTile_003E5__3 = null;
					_003Ci_003E5__2++;
					break;
				}
				if (_003Ci_003E5__2 < generatedTileCount)
				{
					_003CnewTile_003E5__3 = elementFrequencyAnalyzer.tileGenerator.GenerateTile(null, questTileProbability);
					foreach (ElementGroupSegment allElementGroupSegment in _003CnewTile_003E5__3.AllElementGroupSegments)
					{
						foreach (KeyValuePair<ElementType, int> element in allElementGroupSegment.Elements)
						{
							elementFrequencyAnalyzer.AddElementCount(element.Key, element.Value);
						}
					}
					elementFrequencyAnalyzer.tileCount++;
					foreach (ElementCountData element2 in elementFrequencyAnalyzer.elements)
					{
						element2.countPerTile = (float)element2.count / (float)elementFrequencyAnalyzer.tileCount;
					}
					_003C_003E2__current = new WaitForSeconds(delay);
					_003C_003E1__state = 1;
					return true;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		[SerializeField]
		private int tileCount;

		[SerializeField]
		private List<ElementCountData> elements;

		[SerializeField]
		private TileGenerator tileGenerator;

		[SerializeField]
		private TileGenConfiguration defaultTileGenConfiguration;

		private World world;

		private Dictionary<ElementType, ElementCountData> elementDataByType = new Dictionary<ElementType, ElementCountData>();

		private TileGenConfiguration modifiedTileGenConfiguration;

		private void AnalyzeMap()
		{
			if (!world)
			{
				world = UnityEngine.Object.FindObjectOfType<World>();
			}
			elements = new List<ElementCountData>();
			elementDataByType = new Dictionary<ElementType, ElementCountData>();
			foreach (Tile allPlacedTile in world.GetAllPlacedTiles())
			{
				tileCount++;
				foreach (ElementGroupSegment allElementGroupSegment in allPlacedTile.AllElementGroupSegments)
				{
					foreach (KeyValuePair<ElementType, int> element in allElementGroupSegment.Elements)
					{
						AddElementCount(element.Key, element.Value);
					}
				}
				tileCount++;
			}
			foreach (ElementCountData element2 in elements)
			{
				element2.countPerTile = (float)element2.count / (float)tileCount;
			}
		}

		private void StartAnalyzingGeneratedTiles(int generatedTileCount = 1000, float questTileProbability = 0.1f, float delay = 0.1f)
		{
			StartCoroutine(AnalyzeGeneratedTiles(generatedTileCount, questTileProbability, delay));
		}

		private IEnumerator AnalyzeGeneratedTiles(int generatedTileCount, float questTileProbability = 0.1f, float delay = 0.1f)
		{
			return new _003CAnalyzeGeneratedTiles_003Ed__9(0)
			{
				_003C_003E4__this = this,
				generatedTileCount = generatedTileCount,
				questTileProbability = questTileProbability,
				delay = delay
			};
		}

		private void AddElementCount(ElementType elementType, int elementCount)
		{
			if (!elementDataByType.ContainsKey(elementType))
			{
				ElementCountData elementCountData = new ElementCountData
				{
					elementType = elementType
				};
				elements.Add(elementCountData);
				elementDataByType.Add(elementType, elementCountData);
			}
			elementDataByType[elementType].count += elementCount;
		}
	}
}
