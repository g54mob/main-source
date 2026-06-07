using Localization;
using UnityEngine;

namespace App.Data
{
	public class Comics : BaseQuest
	{
		public string ReqScoreList;

		public string ScoresBorder;

		public bool StoryComics;

		public string SpriteListGold;

		public string SpriteListSilver;

		public string SpriteListBronze;

		private Sprite[] spritesGold;

		private Sprite[] spritesSilver;

		private Sprite[] spritesBronze;

		private string[] textsGold;

		private string[] textsSilver;

		private string[] textsBronze;

		private string[] parsedReqScoreList;

		private int[] scoresBorderInt;

		private float[] scoresBorderFloat;

		public string[] ParsedReqScoreList => parsedReqScoreList ?? (parsedReqScoreList = ReqScoreList.Split(','));

		public int[] ScoresBorderInt
		{
			get
			{
				if (scoresBorderInt != null && scoresBorderInt.Length == 3)
				{
					return scoresBorderInt;
				}
				string[] array = ScoresBorder.Split(';');
				scoresBorderInt = new int[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					int result = 0;
					int.TryParse(array[i], out result);
					scoresBorderInt[i] = result;
				}
				return scoresBorderInt;
			}
		}

		public float[] ScoresBorderFloat
		{
			get
			{
				if (scoresBorderFloat != null)
				{
					return scoresBorderFloat;
				}
				scoresBorderFloat = new float[ScoresBorderInt.Length];
				float num = GetMaxComcisScore();
				for (int i = 0; i < scoresBorderFloat.Length; i++)
				{
					scoresBorderFloat[i] = (float)ScoresBorderInt[i] / num;
				}
				return scoresBorderFloat;
			}
		}

		private Sprite GetListSprite(string key)
		{
			Sprite sprite = Logic.LoadSprite(key);
			if (sprite == null)
			{
				sprite = Logic.LoadSprite(key.Replace(" ", ""));
			}
			return sprite;
		}

		private Sprite[] ParseSprites(string spriteList)
		{
			string[] array = spriteList.Split(';');
			int num = array.Length;
			if (array[^1].Length == 0)
			{
				num--;
			}
			Sprite[] array2 = new Sprite[num];
			for (int i = 0; i < array2.Length; i++)
			{
				if (array[i].Length > 0)
				{
					Sprite listSprite = GetListSprite(array[i] + Logic.GetCurLangSufix());
					if (listSprite == null)
					{
						listSprite = GetListSprite(array[i]);
					}
					array2[i] = listSprite;
				}
			}
			return array2;
		}

		public Sprite[] GetSprites(int score)
		{
			spritesGold = ParseSprites(SpriteListGold);
			spritesSilver = ParseSprites(SpriteListSilver);
			spritesBronze = ParseSprites(SpriteListBronze);
			return score switch
			{
				3 => spritesGold, 
				2 => spritesSilver, 
				_ => spritesBronze, 
			};
		}

		private string[] ParseTexts(string score)
		{
			int num = ((score == "gold") ? SpriteListGold.Split(';').Length : ((!(score == "silver")) ? SpriteListBronze.Split(';').Length : SpriteListSilver.Split(';').Length));
			string[] array = new string[num];
			if (num > 0)
			{
				string key = string.Format("{0}_{1}_{2}", KeyName, score, "0");
				array[0] = (TextResources.IsKeyExists(key) ? TextResources.GetString(key) : "");
			}
			for (int i = 1; i < num; i++)
			{
				string key2 = $"{KeyName}_{score}_{i.ToString()}";
				array[i] = (TextResources.IsKeyExists(key2) ? TextResources.GetString(key2) : null);
			}
			return array;
		}

		public string[] GetTexts(int score)
		{
			textsGold = ParseTexts("gold");
			textsSilver = ParseTexts("silver");
			textsBronze = ParseTexts("bronze");
			return score switch
			{
				3 => textsGold, 
				2 => textsSilver, 
				_ => textsBronze, 
			};
		}

		public override int GetRewardFromMedal(int score)
		{
			return 0;
		}

		public int GetSumComicsScore()
		{
			int num = 0;
			string[] array = ParsedReqScoreList;
			foreach (string text in array)
			{
				BaseQuest baseQuestByKeyName = Logic.GetBaseQuestByKeyName(text);
				if (baseQuestByKeyName == null)
				{
					continue;
				}
				if (Logic.GetModel().curPreview.IsQuestDone(text) && !baseQuestByKeyName.Is<ForumQuest>())
				{
					if (baseQuestByKeyName.Is<Comics>())
					{
						QuestLine.UpdateComicsMedal(QuestLine.GetQuest(text));
					}
					if (QuestLine.IsLoadedInMemory(text))
					{
						num += QuestLine.GetQuest(text).GetScore();
					}
				}
				else
				{
					QuestLine.Quest quest = QuestLine.GetQuest(baseQuestByKeyName.KeyName);
					if (baseQuestByKeyName.Is<ForumQuest>() && quest != null && quest.IsCompleted())
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetMaxComcisScore()
		{
			int num = 0;
			string[] array = ParsedReqScoreList;
			foreach (string text in array)
			{
				if (text != "" && !Logic.GetBaseQuestByKeyName(text).Is<ForumQuest>())
				{
					num += 3;
				}
			}
			return num;
		}

		public override string GetScoreTextForEpoch()
		{
			return TextResources.GetString("Score") + " " + GetSumComicsScore() + " / " + GetMaxComcisScore();
		}

		public void UpdateComicsState()
		{
			QuestLine.Quest quest = QuestLine.GetQuest(KeyName);
			quest.SetOpened(state: true);
			Logic.UpdateCurGlobalScore(quest);
		}

		public override void Start()
		{
			QuestLine.UpdateOrAddQuest(this);
			QuestLine.SetCurrentQuest(this);
			QuestLine.UpdateComicsesScore();
			Logic.UpdateGameSaves();
			SoundSystem sound = Logic.GetSound();
			sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", 0f);
			sound.ActiveMusic("Monokanal/WhileTrueLearn_Music_For_Story");
			Logic.ComicsController.gameObject.SetActive(value: true);
			Logic.ComicsController.Init(this);
		}

		public override void End()
		{
			base.End();
			SoundSystem sound = Logic.GetSound();
			sound.ActiveMusic("Monokanal/WhileTrueLearn_Music_For_Gameplay");
			sound.SetLoopVolume("Monokanal/WhileTrueLearn_RoomTone_Loop", Logic.GetModel().globalSaves.soundVolume);
			QuestLine.UpdateComicsMedal(QuestLine.GetQuest(KeyName));
			Logic.CheckEpochAchivments();
			Logic.Controller.Tree.Redraw();
		}
	}
}
