using System;
using System.Collections.Generic;
using System.Linq;
using Simulator;
using Simulator.GameWorld;
using Tabletop.Preview3D;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public static class Collection
	{
		private static Dictionary<int, int> _completeMiniatures = new Dictionary<int, int>();

		private static Dictionary<int, HashSet<int>> _partialMiniatures = new Dictionary<int, HashSet<int>>();

		private static Dictionary<Vector2Int, int> _pieces = new Dictionary<Vector2Int, int>();

		private static Dictionary<int, MiniaturePaintingState> _miniaturesPaintingState = new Dictionary<int, MiniaturePaintingState>();

		private static Dictionary<int, MiniatureProductData> _miniatureProducts = new Dictionary<int, MiniatureProductData>();

		private static CollectionWargameSquad[] _wargameSquads = new CollectionWargameSquad[CollectionSettings.SquadSlots];

		private static int _totalMiniatureCount;

		private static int _totalRareMiniatureCount;

		private static Dictionary<ELicense, int> _totalMiniatureCountByLicense = new Dictionary<ELicense, int>();

		private static Dictionary<ELicense, int> _totalRareMiniatureCountByLicense = new Dictionary<ELicense, int>();

		private static Dictionary<EMiniatureArmy, int> _totalMiniatureCountByArmy = new Dictionary<EMiniatureArmy, int>();

		private static Dictionary<ELicense, Dictionary<EMiniatureArmy, int>> _totalMiniatureCountByLicenseAndArmy = new Dictionary<ELicense, Dictionary<EMiniatureArmy, int>>();

		private static int _completedRareMiniatureCount;

		private static Dictionary<ELicense, int> _completedMiniatureCountByLicense = new Dictionary<ELicense, int>();

		private static Dictionary<ELicense, int> _completedRareMiniatureCountByLicense = new Dictionary<ELicense, int>();

		private static Dictionary<EMiniatureArmy, int> _completedMiniatureCountByArmy = new Dictionary<EMiniatureArmy, int>();

		private static Dictionary<ELicense, Dictionary<EMiniatureArmy, int>> _completedMiniatureCountByLicenseAndArmy = new Dictionary<ELicense, Dictionary<EMiniatureArmy, int>>();

		private static HashSet<int> _miniatureWithNewPieces = new HashSet<int>();

		public static ECollectionMode Mode { get; private set; }

		public static List<MiniaturePieceData> NewPieces { get; private set; } = new List<MiniaturePieceData>();

		public static event Action CollectedNewPieces;

		public static event Action<int, bool> StartAssembleMiniature;

		public static event Action<int> CompleteAssembleMiniature;

		public static event Action<int> WantsToPaintMiniature;

		public static event Action<int, int> PaintedMiniature;

		public static CollectionElement GetCollectionElement(int uid)
		{
			return GetCollectionElement(MiniatureDatabase.Get(uid));
		}

		public static CollectionElement GetCollectionElement(MiniatureData data)
		{
			if (data == null)
			{
				return default(CollectionElement);
			}
			bool flag = false;
			if (_partialMiniatures.TryGetValue(data.UID, out var value))
			{
				flag = true;
			}
			if (_completeMiniatures.TryGetValue(data.UID, out var value2))
			{
				flag = true;
			}
			int paintedCount = 0;
			if (_miniaturesPaintingState.TryGetValue(data.UID, out var value3))
			{
				paintedCount = value3.count;
				flag = true;
			}
			if (flag)
			{
				return new CollectionElement(data, value2, paintedCount, value);
			}
			return new CollectionElement(data);
		}

		public static MiniatureCollectionState GetMiniatureState(int uid)
		{
			_completeMiniatures.TryGetValue(uid, out var value);
			int painted = 0;
			if (_miniaturesPaintingState.TryGetValue(uid, out var value2))
			{
				painted = value2.count;
			}
			int currentPieces = 0;
			List<int> list = new List<int>();
			for (int i = 0; i < 5; i++)
			{
				list.Add(i);
			}
			if (_partialMiniatures.TryGetValue(uid, out var value3))
			{
				foreach (int item in value3)
				{
					list.Remove(item);
				}
				currentPieces = value3.Count;
			}
			return new MiniatureCollectionState(value, painted, currentPieces, list);
		}

		public static int GetPieceCount(Vector2Int uid)
		{
			if (_pieces.TryGetValue(uid, out var value))
			{
				return value;
			}
			return 0;
		}

		public static IEnumerable<CollectionElement> GetPaintableCollectionElements()
		{
			foreach (var (uid, num3) in _completeMiniatures)
			{
				if (num3 > 0)
				{
					yield return GetCollectionElement(uid);
				}
			}
		}

		public static IEnumerable<CollectionElement> GetCollectionElementsWithNewPieces()
		{
			foreach (int miniatureWithNewPiece in _miniatureWithNewPieces)
			{
				yield return GetCollectionElement(miniatureWithNewPiece);
			}
		}

		public static IEnumerable<CollectionElement> GetSellableCollectionElements()
		{
			Dictionary<int, int> squadSelectedMiniatures = GetSquadSelectedMiniatures();
			int key;
			foreach (KeyValuePair<int, MiniaturePaintingState> item in _miniaturesPaintingState)
			{
				item.Deconstruct(out key, out var value);
				int num = key;
				MiniaturePaintingState miniaturePaintingState = value;
				if (squadSelectedMiniatures.TryGetValue(num, out var value2))
				{
					if (miniaturePaintingState.count > value2)
					{
						yield return GetCollectionElement(num);
					}
				}
				else if (miniaturePaintingState.count > 0)
				{
					yield return GetCollectionElement(num);
				}
			}
			foreach (KeyValuePair<int, int> completeMiniature in _completeMiniatures)
			{
				completeMiniature.Deconstruct(out key, out var value3);
				int uid = key;
				if (value3 > 0)
				{
					yield return GetCollectionElement(uid);
				}
			}
		}

		public static IEnumerable<CollectionElement> GetPaintedCollectionElements()
		{
			foreach (KeyValuePair<int, MiniaturePaintingState> item in _miniaturesPaintingState)
			{
				item.Deconstruct(out var key, out var value);
				int uid = key;
				if (value.count > 0)
				{
					yield return GetCollectionElement(uid);
				}
			}
		}

		public static IEnumerable<CollectionElement> GetAllCollectionElements()
		{
			foreach (MiniatureData item in MiniatureDatabase.Enumerate())
			{
				yield return GetCollectionElement(item);
			}
		}

		public static ECollectionResult Collect(MiniaturePieceData pieceData)
		{
			if (_pieces.ContainsKey(pieceData.UID))
			{
				_pieces[pieceData.UID]++;
			}
			else
			{
				_pieces.Add(pieceData.UID, 1);
			}
			ECollectionResult result = ECollectionResult.NONE;
			if (_partialMiniatures.TryGetValue(pieceData.UID.x, out var value))
			{
				if (value.Add(pieceData.UID.y))
				{
					result = CheckCompletion(pieceData.MiniatureData);
				}
			}
			else
			{
				_partialMiniatures.Add(pieceData.UID.x, new HashSet<int> { pieceData.UID.y });
				if (!_completeMiniatures.ContainsKey(pieceData.UID.x))
				{
					result = ECollectionResult.STARTED_NEW;
				}
			}
			return result;
		}

		private static ECollectionResult CheckCompletion(MiniatureData miniatureData)
		{
			if (_partialMiniatures.TryGetValue(miniatureData.UID, out var value) && value.Count == miniatureData.NecessaryPiecesCount)
			{
				if (_completeMiniatures.ContainsKey(miniatureData.UID))
				{
					return ECollectionResult.COMPLETED;
				}
				return ECollectionResult.COMPLETED_NEW;
			}
			return ECollectionResult.NONE;
		}

		public static bool CanAssemble(CollectionElement collectionElement)
		{
			if (_partialMiniatures.TryGetValue(collectionElement.UID, out var value))
			{
				return value.Count == collectionElement.data.NecessaryPiecesCount;
			}
			return false;
		}

		public static void Assemble(int uid)
		{
			Assemble(uid, assembleAnimation: true);
		}

		private static void Assemble(int uid, bool assembleAnimation)
		{
			if (!_partialMiniatures.TryGetValue(uid, out var value))
			{
				return;
			}
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int item in value)
			{
				Vector2Int key = new Vector2Int(uid, item);
				_pieces[key]--;
				if (_pieces[key] > 0)
				{
					hashSet.Add(item);
				}
				else
				{
					_pieces.Remove(key);
				}
			}
			if (hashSet.Count > 0)
			{
				_partialMiniatures[uid] = hashSet;
			}
			else
			{
				_partialMiniatures.Remove(uid);
			}
			if (_completeMiniatures.TryGetValue(uid, out var value2))
			{
				_completeMiniatures[uid]++;
				if (value2 == 0 && (!_miniaturesPaintingState.TryGetValue(uid, out var value3) || value3.count == 0))
				{
					OnAddNewMiniatureToStatistics(uid);
				}
				if (assembleAnimation)
				{
					StartAssemble(uid, newMiniature: false);
				}
			}
			else
			{
				_completeMiniatures.Add(uid, 1);
				if (!_miniaturesPaintingState.TryGetValue(uid, out var value4) || value4.count == 0)
				{
					OnAddNewMiniatureToStatistics(uid);
				}
				if (assembleAnimation)
				{
					StartAssemble(uid, newMiniature: true);
				}
			}
			GameAnalytics.NewOrAddDesignEvent("id_analytics_fig_assemble", 1f);
		}

		private static void StartAssemble(int uid, bool newMiniature)
		{
			World.PlayerCharacter.ShowHandsContent(show: false);
			TabletopPreview3DManager.Instance.AssembleMiniature(uid, OnCompleteAssembly);
			Collection.StartAssembleMiniature?.Invoke(uid, newMiniature);
		}

		private static void OnCompleteAssembly(int uid)
		{
			World.PlayerCharacter.ShowHandsContent(show: true);
			Collection.CompleteAssembleMiniature?.Invoke(uid);
		}

		public static void DebugAssembleAllMiniatures()
		{
			foreach (KeyValuePair<int, HashSet<int>> item in _partialMiniatures.ToList())
			{
				item.Deconstruct(out var key, out var value);
				int uid = key;
				HashSet<int> hashSet = value;
				MiniatureData miniatureData = MiniatureDatabase.Get(uid);
				if (hashSet.Count == miniatureData.NecessaryPiecesCount)
				{
					Assemble(uid, assembleAnimation: false);
				}
			}
		}

		public static void DebugCollectAllMiniatures(int count)
		{
			foreach (MiniatureData item in MiniatureDatabase.Enumerate())
			{
				if (item.Product == null || item.Assembly == null || item.Preview3D == null || item.Wargame == null)
				{
					Debug.LogError(item?.ToString() + " has not been setup correctly");
				}
				else if (_completeMiniatures.ContainsKey(item.UID))
				{
					_completeMiniatures[item.UID] += count;
				}
				else
				{
					_completeMiniatures.Add(item.UID, count);
				}
			}
		}

		public static void DebugCollectAllPieces(int count)
		{
			foreach (MiniatureData item in MiniatureDatabase.Enumerate())
			{
				if (item.Product == null || item.Assembly == null || item.Preview3D == null || item.Wargame == null)
				{
					Debug.LogError(item?.ToString() + " has not been setup correctly");
					continue;
				}
				foreach (MiniaturePieceData piece in item.GetPieces())
				{
					for (int i = 0; i < count; i++)
					{
						Collect(piece);
					}
				}
			}
		}

		public static void DebugCollectPieces(int uid)
		{
			MiniatureData miniatureData = MiniatureDatabase.Get(uid);
			if ((object)miniatureData != null)
			{
				if (miniatureData.Product == null || miniatureData.Assembly == null || miniatureData.Preview3D == null || miniatureData.Wargame == null)
				{
					Debug.LogError(miniatureData?.ToString() + " has not been setup correctly");
				}
				{
					foreach (MiniaturePieceData piece in miniatureData.GetPieces())
					{
						Collect(piece);
					}
					return;
				}
			}
			Debug.LogError("No MiniatureData with UID " + uid);
		}

		public static void StartPainting(int miniatureUID)
		{
			Collection.WantsToPaintMiniature?.Invoke(miniatureUID);
		}

		public static int PaintMiniature(int miniatureUID, int score)
		{
			if (!_completeMiniatures.TryGetValue(miniatureUID, out var value) || value == 0)
			{
				return 0;
			}
			_completeMiniatures[miniatureUID]--;
			float eventValue = (float)score / (float)PaintingSettings.GetMaxPaintingGameScore() * 100f;
			GameAnalytics.NewOrAddDesignEvent("id_analytics_fig_paint", 1f);
			GameAnalytics.NewDesignEvent("id_analytics_fig_paintminigame", eventValue);
			if (_miniaturesPaintingState.TryGetValue(miniatureUID, out var value2))
			{
				if (score > value2.paintScore)
				{
					_miniaturesPaintingState[miniatureUID] = new MiniaturePaintingState(value2.count + 1, score);
					Collection.PaintedMiniature?.Invoke(miniatureUID, score);
					return score;
				}
				_miniaturesPaintingState[miniatureUID] = new MiniaturePaintingState(value2.count + 1, value2.paintScore);
				Collection.PaintedMiniature?.Invoke(miniatureUID, value2.paintScore);
				return value2.paintScore;
			}
			_miniaturesPaintingState[miniatureUID] = new MiniaturePaintingState(1, score);
			Collection.PaintedMiniature?.Invoke(miniatureUID, score);
			return score;
		}

		public static int GetPreviewPaintScore(int miniatureUID)
		{
			if (_miniaturesPaintingState.TryGetValue(miniatureUID, out var value) && value.count > 0)
			{
				return value.paintScore;
			}
			return 0;
		}

		public static int GetPaintMaxScore(int miniatureUID)
		{
			if (_miniaturesPaintingState.TryGetValue(miniatureUID, out var value))
			{
				return value.paintScore;
			}
			return 0;
		}

		public static int GetPaintedCount(int miniatureUID)
		{
			if (_miniaturesPaintingState.TryGetValue(miniatureUID, out var value))
			{
				return value.count;
			}
			return 0;
		}

		public static void DebugPaintAllMiniatures()
		{
			int maxPaintingGameScore = PaintingSettings.GetMaxPaintingGameScore();
			foreach (KeyValuePair<int, int> item in _completeMiniatures.ToList())
			{
				item.Deconstruct(out var key, out var value);
				int miniatureUID = key;
				int num = value;
				for (int i = 0; i < num; i++)
				{
					PaintMiniature(miniatureUID, maxPaintingGameScore);
				}
			}
		}

		public static void Unpack(MiniatureBoxProductData miniatureProductData)
		{
			List<MiniaturePieceData> list = miniatureProductData.ComputeMiniaturePiecePool();
			if (list.Count < miniatureProductData.PiecesByBox)
			{
				Debug.LogError("Piece pool has not enough pieces (" + list.Count + "/" + miniatureProductData.PiecesByBox + ")");
			}
			List<Vector2Int> list2 = new List<Vector2Int>();
			NewPieces.Clear();
			int num = miniatureProductData.PiecesByBox;
			int num2 = 0;
			while (num > 0 && num2 < 100)
			{
				num2++;
				MiniaturePieceData miniaturePieceData = list[UnityEngine.Random.Range(0, list.Count)];
				if (!list2.Contains(miniaturePieceData.UID))
				{
					list2.Add(miniaturePieceData.UID);
					Collect(miniaturePieceData);
					NewPieces.Add(miniaturePieceData);
					_miniatureWithNewPieces.Add(miniaturePieceData.UID.x);
					num--;
				}
			}
			Collection.CollectedNewPieces?.Invoke();
			SaveManager.AutoSaveAfterClassicUpdate();
		}

		public static MiniaturePieceData WinOnePiece(ELicense license, MiniatureRarityModifier miniatureRarityModifier, EMiniatureArmy army)
		{
			List<MiniaturePieceData> list = MiniatureDatabase.ComputeMiniaturePiecePool(license, miniatureRarityModifier, army);
			MiniaturePieceData miniaturePieceData = list[UnityEngine.Random.Range(0, list.Count)];
			NewPieces.Add(miniaturePieceData);
			_miniatureWithNewPieces.Add(miniaturePieceData.UID.x);
			return miniaturePieceData;
		}

		public static bool MiniatureHasNewPiece(int uid)
		{
			return _miniatureWithNewPieces.Contains(uid);
		}

		public static void MiniaturePiecesHaveBeenLookedAt(int uid)
		{
			_miniatureWithNewPieces.Remove(uid);
		}

		private static void OnAddNewMiniatureToStatistics(int uid)
		{
			MiniatureData miniatureData = MiniatureDatabase.Get(uid);
			_completedMiniatureCountByLicense[miniatureData.License]++;
			_completedMiniatureCountByArmy[miniatureData.Army]++;
			_completedMiniatureCountByLicenseAndArmy[miniatureData.License][miniatureData.Army]++;
			if (miniatureData.Type != EMiniatureType.COMMON)
			{
				_completedRareMiniatureCount++;
				_completedRareMiniatureCountByLicense[miniatureData.License]++;
			}
		}

		private static void OnRemoveMiniatureFromStatistics(int uid)
		{
			MiniatureData miniatureData = MiniatureDatabase.Get(uid);
			_completedMiniatureCountByLicense[miniatureData.License]--;
			_completedMiniatureCountByArmy[miniatureData.Army]--;
			_completedMiniatureCountByLicenseAndArmy[miniatureData.License][miniatureData.Army]--;
			if (miniatureData.Type != EMiniatureType.COMMON)
			{
				_completedRareMiniatureCount--;
				_completedRareMiniatureCountByLicense[miniatureData.License]--;
			}
		}

		private static void FetchMiniatureTotals()
		{
			_totalMiniatureCount = MiniatureDatabase.GetCount();
			_totalRareMiniatureCount = MiniatureDatabase.GetHeroCount();
			foreach (ELicense value in Enum.GetValues(typeof(ELicense)))
			{
				_totalMiniatureCountByLicense[value] = MiniatureDatabase.GetCount(value);
				_totalRareMiniatureCountByLicense[value] = MiniatureDatabase.GetHeroCount(value);
				Dictionary<EMiniatureArmy, int> dictionary = new Dictionary<EMiniatureArmy, int>();
				foreach (EMiniatureArmy value2 in Enum.GetValues(typeof(EMiniatureArmy)))
				{
					dictionary[value2] = MiniatureDatabase.GetCount(value, value2);
				}
				_totalMiniatureCountByLicenseAndArmy[value] = dictionary;
			}
			foreach (EMiniatureArmy value3 in Enum.GetValues(typeof(EMiniatureArmy)))
			{
				_totalMiniatureCountByArmy[value3] = MiniatureDatabase.GetCount(value3);
			}
		}

		private static void InitMiniatureCounts()
		{
			_completedRareMiniatureCount = 0;
			_completedRareMiniatureCountByLicense.Clear();
			_completedMiniatureCountByArmy.Clear();
			_completedMiniatureCountByLicense.Clear();
			_completedMiniatureCountByLicenseAndArmy.Clear();
			foreach (ELicense value2 in Enum.GetValues(typeof(ELicense)))
			{
				_completedMiniatureCountByLicense.Add(value2, 0);
				_completedRareMiniatureCountByLicense.Add(value2, 0);
				Dictionary<EMiniatureArmy, int> dictionary = new Dictionary<EMiniatureArmy, int>();
				foreach (EMiniatureArmy value3 in Enum.GetValues(typeof(EMiniatureArmy)))
				{
					dictionary.Add(value3, 0);
				}
				_completedMiniatureCountByLicenseAndArmy.Add(value2, dictionary);
			}
			foreach (EMiniatureArmy value4 in Enum.GetValues(typeof(EMiniatureArmy)))
			{
				_completedMiniatureCountByArmy.Add(value4, 0);
			}
			foreach (var (num3, num4) in _completeMiniatures)
			{
				MiniaturePaintingState value;
				if (num4 > 0)
				{
					OnAddNewMiniatureToStatistics(num3);
				}
				else if (_miniaturesPaintingState.TryGetValue(num3, out value) && value.count > 0)
				{
					OnAddNewMiniatureToStatistics(num3);
				}
			}
		}

		public static float GetGlobalCompletionPercentage()
		{
			if (_totalMiniatureCount == 0)
			{
				return 0f;
			}
			return (float)_completeMiniatures.Count / (float)_totalMiniatureCount;
		}

		public static float GetGlobalCompletionPercentage(ELicense license)
		{
			if (_totalMiniatureCountByLicense[license] == 0)
			{
				return 0f;
			}
			return (float)_completedMiniatureCountByLicense[license] / (float)_totalMiniatureCountByLicense[license];
		}

		public static float GetRareCompletionPercentage()
		{
			if (_totalRareMiniatureCount == 0)
			{
				return 0f;
			}
			return (float)_completedRareMiniatureCount / (float)_totalRareMiniatureCount;
		}

		public static float GetRareCompletionPercentage(ELicense license)
		{
			if (_totalRareMiniatureCountByLicense[license] == 0)
			{
				return 0f;
			}
			return (float)_completedRareMiniatureCountByLicense[license] / (float)_totalRareMiniatureCountByLicense[license];
		}

		public static float GetArmyCompletionPercentage(EMiniatureArmy army)
		{
			if (_totalMiniatureCountByArmy[army] == 0)
			{
				return 0f;
			}
			return (float)_completedMiniatureCountByArmy[army] / (float)_totalMiniatureCountByArmy[army];
		}

		public static float GetArmyCompletionPercentage(ELicense license, EMiniatureArmy army)
		{
			if (_totalMiniatureCountByLicenseAndArmy[license][army] == 0)
			{
				return 0f;
			}
			return (float)_completedMiniatureCountByLicenseAndArmy[license][army] / (float)_totalMiniatureCountByLicenseAndArmy[license][army];
		}

		public static bool AddToDisplay(int miniatureUID, bool inSale, out MiniatureProductData data, out bool painted)
		{
			if (_miniaturesPaintingState.TryGetValue(miniatureUID, out var value) && value.count > 0)
			{
				if (value.count == 1 && (!_completeMiniatures.TryGetValue(miniatureUID, out var value2) || value2 == 0))
				{
					OnRemoveMiniatureFromStatistics(miniatureUID);
				}
				_miniaturesPaintingState[miniatureUID] = new MiniaturePaintingState(value.count - 1, value.paintScore);
				painted = true;
			}
			else
			{
				if (!_completeMiniatures.TryGetValue(miniatureUID, out var value3) || value3 <= 0)
				{
					data = null;
					painted = false;
					return false;
				}
				if (value3 == 1)
				{
					OnRemoveMiniatureFromStatistics(miniatureUID);
				}
				_completeMiniatures[miniatureUID]--;
				painted = false;
			}
			if (_miniatureProducts.TryGetValue(miniatureUID, out data) && data != null)
			{
				if (inSale)
				{
					data.NumberInSale++;
				}
				else
				{
					data.NumberInDisplay++;
				}
			}
			else
			{
				MiniatureData miniatureData = MiniatureDatabase.Get(miniatureUID);
				data = MiniatureProductData.Create(miniatureUID, miniatureData.NameLocaKey);
				if (inSale)
				{
					data.NumberInSale = 1;
				}
				else
				{
					data.NumberInDisplay = 1;
				}
				_miniatureProducts.Add(miniatureUID, data);
			}
			return true;
		}

		public static void RemoveFromDisplay(MiniatureProduct miniatureProduct, bool bought, bool wasInSale)
		{
			int num = -miniatureProduct.ProductData.UID;
			if (!_miniatureProducts.TryGetValue(num, out var value))
			{
				return;
			}
			if (wasInSale)
			{
				if (value.NumberInSale > 0)
				{
					value.NumberInSale--;
				}
			}
			else if (value.NumberInDisplay > 0)
			{
				value.NumberInDisplay--;
			}
			if (bought)
			{
				return;
			}
			int value4;
			if (miniatureProduct.Painted)
			{
				if (_miniaturesPaintingState.TryGetValue(num, out var value2))
				{
					_miniaturesPaintingState[num] = new MiniaturePaintingState(value2.count + 1, value2.paintScore);
				}
				else
				{
					_miniaturesPaintingState[num] = new MiniaturePaintingState(1, 1);
				}
				if (value2.count == 0 && (!_completeMiniatures.TryGetValue(num, out var value3) || value3 == 0))
				{
					OnAddNewMiniatureToStatistics(num);
				}
			}
			else if (_completeMiniatures.TryGetValue(num, out value4))
			{
				_completeMiniatures[num]++;
				if (value4 == 0)
				{
					OnAddNewMiniatureToStatistics(num);
				}
			}
			else
			{
				_completeMiniatures.Add(num, 1);
				OnAddNewMiniatureToStatistics(num);
			}
		}

		public static MiniatureProductData GetMiniatureProductData(int productUID)
		{
			return _miniatureProducts[-productUID];
		}

		public static CollectionWargameSquad GetSquadAtIndex(int index)
		{
			return _wargameSquads[index];
		}

		public static void SetSquadAtIndex(int index, CollectionWargameSquad squad)
		{
			_wargameSquads[index] = squad;
		}

		public static void AddWargameResultToSquad(int index, bool victory)
		{
			CollectionWargameSquad other = _wargameSquads[index];
			_wargameSquads[index] = new CollectionWargameSquad(other, victory);
		}

		public static void DeleteSquad(int index)
		{
			_wargameSquads[index] = default(CollectionWargameSquad);
		}

		public static Dictionary<int, int> GetSquadSelectedMiniatures()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
			for (int i = 0; i < _wargameSquads.Length; i++)
			{
				if (!_wargameSquads[i].Exists)
				{
					continue;
				}
				dictionary2.Clear();
				int value;
				int key;
				for (int j = 0; j < WargameSettings.SquadSize; j++)
				{
					int miniatureUID = _wargameSquads[i].GetMiniatureUID(j);
					if (miniatureUID > 0)
					{
						if (dictionary2.ContainsKey(miniatureUID))
						{
							value = miniatureUID;
							key = dictionary2[value]++;
						}
						else
						{
							dictionary2[miniatureUID] = 1;
						}
					}
				}
				foreach (KeyValuePair<int, int> item in dictionary2)
				{
					item.Deconstruct(out key, out value);
					int key2 = key;
					int num = value;
					if (!dictionary.TryGetValue(key2, out var value2) || num > value2)
					{
						dictionary[key2] = num;
					}
				}
			}
			return dictionary;
		}

		public static bool IsMiniatureAvailableForSquad(CollectionWargameSquad squad, MiniatureData data)
		{
			if (data.Wargame == null)
			{
				return false;
			}
			if (!squad.Exists)
			{
				return true;
			}
			if (squad.Armies.IsValid() && squad.Armies.Count == WargameSettings.MaxArmyBySquad)
			{
				bool flag = false;
				foreach (EMiniatureArmy army in squad.Armies)
				{
					if (data.Army == army)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			int num = 0;
			for (int i = 0; i < WargameSettings.SquadSize; i++)
			{
				if (squad.GetMiniatureUID(i) == data.UID)
				{
					num++;
				}
			}
			return num == 0;
		}

		public static int GetValidSquadsCount()
		{
			return _wargameSquads.Count((CollectionWargameSquad s) => s.Exists && s.Valid);
		}

		public static void Load()
		{
			LoadCollection();
			FetchMiniatureTotals();
			InitMiniatureCounts();
		}

		private static void LoadCollection()
		{
			_completeMiniatures.Clear();
			_miniaturesPaintingState.Clear();
			TabletopSave currentSaveAs = SaveManager.GetCurrentSaveAs<TabletopSave>();
			List<int> completeMiniaturesKeys = currentSaveAs.collection.completeMiniaturesKeys;
			List<int> completeMiniaturesValues = currentSaveAs.collection.completeMiniaturesValues;
			List<int> miniaturesPaintingScores = currentSaveAs.collection.miniaturesPaintingScores;
			List<int> miniaturesPaintedCount = currentSaveAs.collection.miniaturesPaintedCount;
			if (completeMiniaturesKeys != null && completeMiniaturesValues != null)
			{
				for (int i = 0; i < completeMiniaturesKeys.Count; i++)
				{
					_completeMiniatures.Add(completeMiniaturesKeys[i], completeMiniaturesValues[i]);
					_miniaturesPaintingState.Add(completeMiniaturesKeys[i], new MiniaturePaintingState(miniaturesPaintedCount[i], miniaturesPaintingScores[i]));
				}
			}
			_partialMiniatures.Clear();
			_pieces.Clear();
			List<Vector2Int> piecesKeys = currentSaveAs.collection.piecesKeys;
			List<int> piecesValues = currentSaveAs.collection.piecesValues;
			if (piecesKeys != null && piecesValues != null)
			{
				for (int j = 0; j < piecesKeys.Count; j++)
				{
					_pieces.Add(piecesKeys[j], piecesValues[j]);
					if (_partialMiniatures.TryGetValue(piecesKeys[j].x, out var value))
					{
						value.Add(piecesKeys[j].y);
						continue;
					}
					_partialMiniatures[piecesKeys[j].x] = new HashSet<int> { piecesKeys[j].y };
				}
			}
			_miniatureProducts.Clear();
			List<int> miniatureProductsKeys = currentSaveAs.collection.miniatureProductsKeys;
			List<int> miniatureProductsInSale = currentSaveAs.collection.miniatureProductsInSale;
			List<int> miniatureProductsInDisplay = currentSaveAs.collection.miniatureProductsInDisplay;
			if (miniatureProductsKeys != null && miniatureProductsInSale != null)
			{
				for (int k = 0; k < miniatureProductsKeys.Count; k++)
				{
					MiniatureData miniatureData = MiniatureDatabase.Get(miniatureProductsKeys[k]);
					int inSale = (miniatureProductsInSale.IsIndexValid(k) ? miniatureProductsInSale[k] : 0);
					int inDisplay = (miniatureProductsInDisplay.IsIndexValid(k) ? miniatureProductsInDisplay[k] : 0);
					MiniatureProductData miniatureProductData = MiniatureProductData.Create(miniatureProductsKeys[k], miniatureData.NameLocaKey, inSale, inDisplay);
					if (miniatureProductData != null)
					{
						_miniatureProducts.Add(miniatureProductsKeys[k], miniatureProductData);
					}
				}
			}
			_wargameSquads = new CollectionWargameSquad[CollectionSettings.SquadSlots];
			if (currentSaveAs.collection.wargameSquads.IsValid())
			{
				for (int l = 0; l < currentSaveAs.collection.wargameSquads.Count; l++)
				{
					_wargameSquads[l] = currentSaveAs.collection.wargameSquads[l];
				}
			}
		}

		public static void Save()
		{
			TabletopSave currentSaveAs = SaveManager.GetCurrentSaveAs<TabletopSave>();
			currentSaveAs.collection.StartSaveProcess();
			int value;
			foreach (KeyValuePair<int, int> completeMiniature in _completeMiniatures)
			{
				completeMiniature.Deconstruct(out var key, out value);
				int num = key;
				int completeCount = value;
				currentSaveAs.collection.SaveCompleteMiniature(num, completeCount, GetPaintMaxScore(num), GetPaintedCount(num));
			}
			foreach (KeyValuePair<Vector2Int, int> piece in _pieces)
			{
				piece.Deconstruct(out var key2, out value);
				Vector2Int uid = key2;
				int count = value;
				currentSaveAs.collection.SavePiece(uid, count);
			}
			foreach (KeyValuePair<int, MiniatureProductData> miniatureProduct in _miniatureProducts)
			{
				miniatureProduct.Deconstruct(out value, out var value2);
				int uid2 = value;
				MiniatureProductData miniatureProductData = value2;
				currentSaveAs.collection.SaveMiniatureProduct(uid2, miniatureProductData.NumberInSale, miniatureProductData.NumberInDisplay);
			}
			currentSaveAs.collection.SaveWargameSquads(_wargameSquads);
		}

		public static void Open(ECollectionMode mode)
		{
			Mode = mode;
			TabletopWorld.TabletopHUDPopup.Open(ETabletopHUDPopupModuleType.COLLECTION);
		}

		public static void Open(ECollectionMode mode, Action<HUDPopupModule> callback)
		{
			Mode = mode;
			TabletopWorld.TabletopHUDPopup.Open(ETabletopHUDPopupModuleType.COLLECTION, callback);
		}

		public static void SetMode(ECollectionMode mode)
		{
			Mode = mode;
		}

		public static ECollectionPaintingMode GetPaintingMode()
		{
			switch (Mode)
			{
			case ECollectionMode.BROWSE:
			case ECollectionMode.SELLING:
			case ECollectionMode.SQUAD_EDITION:
			case ECollectionMode.SQUAD_SELECTION:
				return ECollectionPaintingMode.PREVIEW;
			case ECollectionMode.PAINTING:
				return ECollectionPaintingMode.NO_PAINT;
			default:
				throw new NotImplementedException();
			}
		}

		public static void Clear()
		{
			_completeMiniatures.Clear();
			_partialMiniatures.Clear();
			_pieces.Clear();
			_miniatureProducts.Clear();
		}
	}
}
