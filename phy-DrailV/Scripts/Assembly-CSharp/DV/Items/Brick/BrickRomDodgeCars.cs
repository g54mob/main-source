using System.Collections;
using System.Collections.Generic;
using DV.UserManagement.Data;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Items.Brick
{
	public class BrickRomDodgeCars : BrickRom
	{
		private class GameEntity
		{
			public BrickSprite sprite;

			public Vector2Int position;

			public bool isPowerUp;

			public int lane;

			public GameEntity(BrickSprite sprite, Vector2Int position, bool isPowerUp, int lane)
			{
				this.sprite = sprite;
				this.position = position;
				this.isPowerUp = isPowerUp;
				this.lane = lane;
			}
		}

		private const string HIGH_SCORE_SAVE_KEY = "HighScore";

		private const int LANES = 3;

		private const int PLAY_AREA_OFFSET_TOP = 10;

		private const int DUDE_OFFSET_X = 2;

		private const int ENTITY_OFFSET_Y = -4;

		private const int SCORE_MAX_DIGITS = 4;

		private const int SCORE_OFFSET_Y = 6;

		private const string ASSET_PATH = "DodgeCars/";

		private const string MUSIC_CLIP_NAME = "DodgeCars_Music_01";

		private const string CLIP_SCORE_NAME = "DodgeCars_Score_01";

		private const string CLIP_DEATH_NAME = "DodgeCars_Die_01";

		private const string CLIP_GAME_START_NAME = "DodgeCars_Start_01";

		private const string CLIP_DODGE_NAME = "DodgeCars_Dodge_01";

		private const string CLIP_POWER_UP_NAME = "DodgeCars_Pickup_01";

		private const string DUDE_SPRITE_PATH = "DodgeCars_Guy";

		private const string CAR_SPRITE_PATH = "DodgeCars_Car";

		private const string COIN_THIN_PATH = "DodgeCars_CoinSide";

		private const string COIN_THICK_PATH = "DodgeCars_CoinFront";

		private const int POWER_UP_RATE = 20;

		private const int POWER_UP_SCORE = 5;

		private const float POWER_UP_ANIMATION_DURATION = 0.1f;

		private const float SPEED_INCREASE_INTERVAL = 5f;

		private const int INITIAL_ENTITY_SPEED = 100;

		private const int ENTITY_SPEED_INCREMENT = 10;

		private GameEntity dudeSpriteWrapped;

		private BrickSprite carSprite;

		private HashSet<GameEntity> activeEntities = new HashSet<GameEntity>();

		private Queue<GameEntity> inactiveCars = new Queue<GameEntity>();

		private Queue<GameEntity> inactivePowerUps = new Queue<GameEntity>();

		private BrickSprite[] numberSprites = new BrickSprite[10];

		private BrickSprite[] powerUpSprites = new BrickSprite[2];

		private float speedIncreaseElapsedTime;

		private float powerUpAnimationElapsedTime;

		private float currentEntitySpeed;

		private int score;

		private int highScore;

		private int entitiesRemoved;

		private int laneHeight;

		private Vector2Int entitySpawnThreshold = new Vector2Int(20, 40);

		private bool canTick;

		private bool powerUpThick;

		private bool canRestart;

		private BrickScreen.BrickBounds screenBounds;

		private AudioClip musicClip;

		private AudioClip scoreClip;

		private AudioClip deathClip;

		private AudioClip gameStartClip;

		private AudioClip dodgeClip;

		private AudioClip clipPowerUp;

		private Coroutine deathCoro;

		private HashSet<GameEntity> entitiesToRemove = new HashSet<GameEntity>();

		public override string GameName { get; protected set; } = "Dodge Cars";

		public BrickRomDodgeCars(BrickAssets assets, BrickScreen screen, BrickAudio audio, User user)
			: base(assets, screen, audio, user)
		{
			screenBounds = screen.GetScreenBounds(includePadding: true);
			laneHeight = (screenBounds.maxY - screenBounds.minY - 10) / 3;
			LoadAudio();
			LoadSprites();
			LoadSavedData();
		}

		private void LoadSavedData()
		{
			saveData = GetSaveData();
			if (saveData == null)
			{
				saveData = new JObject();
			}
			else
			{
				highScore = saveData.Value<int>("HighScore");
			}
		}

		private void LoadAudio()
		{
			musicClip = Resources.Load<AudioClip>("DodgeCars/DodgeCars_Music_01");
			if (musicClip == null)
			{
				Debug.LogError("Failed to load music clip for Dodge Cars");
			}
			scoreClip = Resources.Load<AudioClip>("DodgeCars/DodgeCars_Score_01");
			if (scoreClip == null)
			{
				Debug.LogError("Failed to load score clip for Dodge Cars");
			}
			deathClip = Resources.Load<AudioClip>("DodgeCars/DodgeCars_Die_01");
			if (deathClip == null)
			{
				Debug.LogError("Failed to load death clip for Dodge Cars");
			}
			gameStartClip = Resources.Load<AudioClip>("DodgeCars/DodgeCars_Start_01");
			if (gameStartClip == null)
			{
				Debug.LogError("Failed to load game start clip for Dodge Cars");
			}
			dodgeClip = Resources.Load<AudioClip>("DodgeCars/DodgeCars_Dodge_01");
			if (dodgeClip == null)
			{
				Debug.LogError("Failed to load dodge clip for Dodge Cars");
			}
			clipPowerUp = Resources.Load<AudioClip>("DodgeCars/DodgeCars_Pickup_01");
			if (clipPowerUp == null)
			{
				Debug.LogError("Failed to load power up clip for Dodge Cars");
			}
		}

		private void LoadSprites()
		{
			Texture2D texture2D = Resources.Load<Texture2D>("DodgeCars/DodgeCars_Guy");
			if (texture2D == null)
			{
				Debug.LogError("Failed to load dude sprite for Dodge Cars");
			}
			BrickSprite sprite = new BrickSprite(texture2D);
			dudeSpriteWrapped = new GameEntity(sprite, Vector2Int.zero, isPowerUp: false, 1);
			Texture2D texture2D2 = Resources.Load<Texture2D>("DodgeCars/DodgeCars_Car");
			carSprite = new BrickSprite(texture2D2);
			if (texture2D2 == null)
			{
				Debug.LogError("Failed to load car sprite for Dodge Cars");
			}
			Texture2D texture2D3 = Resources.Load<Texture2D>("DodgeCars/DodgeCars_CoinSide");
			if (texture2D3 == null)
			{
				Debug.LogError("Failed to load thin coin sprite for Dodge Cars");
			}
			powerUpSprites[0] = new BrickSprite(texture2D3);
			Texture2D texture2D4 = Resources.Load<Texture2D>("DodgeCars/DodgeCars_CoinFront");
			if (texture2D4 == null)
			{
				Debug.LogError("Failed to load thick coin sprite for Dodge Cars");
			}
			powerUpSprites[1] = new BrickSprite(texture2D4);
			for (int i = 0; i < 10; i++)
			{
				numberSprites[i] = assets.GetAsset((BrickAssets.BrickAssetType)i);
			}
		}

		public override void Tick()
		{
			if (!canTick || base.GamePaused)
			{
				return;
			}
			speedIncreaseElapsedTime += 1f / 30f;
			if (speedIncreaseElapsedTime >= 5f)
			{
				currentEntitySpeed += 10f;
				speedIncreaseElapsedTime = 0f;
			}
			powerUpAnimationElapsedTime += 1f / 30f;
			if (powerUpAnimationElapsedTime >= 0.1f)
			{
				powerUpAnimationElapsedTime = 0f;
				powerUpThick = !powerUpThick;
				foreach (GameEntity activeEntity in activeEntities)
				{
					if (activeEntity.isPowerUp)
					{
						activeEntity.sprite = powerUpSprites[powerUpThick ? 1 : 0];
					}
				}
			}
			int distance = (int)(currentEntitySpeed * (1f / 30f));
			UpdateEntities(distance);
			DrawAll();
		}

		protected override void StartGame()
		{
			EndGame();
			screen.ClearScreen();
			score = 0;
			entitiesRemoved = 0;
			currentEntitySpeed = 100f;
			speedIncreaseElapsedTime = 0f;
			dudeSpriteWrapped.lane = 1;
			int num = (laneHeight - dudeSpriteWrapped.sprite.size.y) / 2 + -4;
			dudeSpriteWrapped.position = new Vector2Int(screenBounds.minX + 2, LaneToHeight(1) + num);
			screen.DrawSprite(dudeSpriteWrapped.sprite, dudeSpriteWrapped.position);
			SpawnEntity();
			DrawAll();
			canTick = true;
			canRestart = false;
			audio.PlayClip(gameStartClip);
			audio.PlayMusic(musicClip, loop: true, 0.2f);
			FireGameStarted();
		}

		protected override void EndGame()
		{
			if (deathCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(deathCoro);
				deathCoro = null;
			}
			audio.StopAllSounds();
			RemoveAllActiveEntities();
			canTick = false;
			FireGameEnded();
		}

		public override void ExecuteInput(BrickInput.BrickInputAction action)
		{
			base.ExecuteInput(action);
			if (base.GamePaused)
			{
				return;
			}
			switch (action)
			{
			case BrickInput.BrickInputAction.Up:
				if (canTick)
				{
					MoveDude(up: true);
				}
				break;
			case BrickInput.BrickInputAction.Down:
				if (canTick)
				{
					MoveDude(up: false);
				}
				break;
			case BrickInput.BrickInputAction.Restart:
				if (canRestart)
				{
					StartGame();
				}
				break;
			}
		}

		private void DrawBoundLines()
		{
			int item = screenBounds.VerticalLimits.Item1;
			item += 10;
			(int, int) horizontalLimits = screenBounds.HorizontalLimits;
			int item2 = horizontalLimits.Item1;
			int item3 = horizontalLimits.Item2;
			int num = (laneHeight - dudeSpriteWrapped.sprite.size.y) / 2;
			for (int i = 0; i < 4; i++)
			{
				int y = i * laneHeight + item - num;
				screen.DrawLine(new Vector2Int(item2, y), new Vector2Int(item3, y), includePadding: false);
				if (i == 3)
				{
					screen.DrawLine(new Vector2Int(item2 - 1, item - num), new Vector2Int(item2 - 1, y), includePadding: false);
					screen.DrawLine(new Vector2Int(item3 + 1, item - num), new Vector2Int(item3 + 1, y), includePadding: false);
				}
			}
		}

		private void MoveDude(bool up)
		{
			int lane = dudeSpriteWrapped.lane;
			int num = Mathf.Clamp(lane + ((!up) ? 1 : (-1)), 0, 2);
			if (num != lane)
			{
				dudeSpriteWrapped.lane = num;
				int num2 = (laneHeight - dudeSpriteWrapped.sprite.size.y) / 2 + -4;
				dudeSpriteWrapped.position = new Vector2Int(screenBounds.minX + 2, LaneToHeight(num) + num2);
				screen.DrawSprite(dudeSpriteWrapped.sprite, dudeSpriteWrapped.position);
				audio.PlayClip(dodgeClip);
				DrawAll();
			}
		}

		private void DrawAll()
		{
			screen.ClearScreen();
			UpdateScore(high: false);
			UpdateScore(high: true);
			foreach (GameEntity activeEntity in activeEntities)
			{
				screen.DrawSprite(activeEntity.sprite, activeEntity.position);
			}
			screen.DrawSprite(dudeSpriteWrapped.sprite, dudeSpriteWrapped.position);
			DrawBoundLines();
		}

		private int LaneToHeight(int lane)
		{
			(int, int) verticalLimits = screenBounds.VerticalLimits;
			int item = verticalLimits.Item1;
			int item2 = verticalLimits.Item2;
			item += 10;
			int num = item2 - item;
			return (int)((float)lane * ((float)num / 3f) + (float)item);
		}

		private void UpdateEntities(int distance)
		{
			entitiesToRemove.Clear();
			if (distance <= 0)
			{
				distance = 1;
			}
			int num = int.MaxValue;
			foreach (GameEntity activeEntity in activeEntities)
			{
				int num2 = activeEntity.position.x - distance;
				if (num2 <= -activeEntity.sprite.size.x)
				{
					entitiesToRemove.Add(activeEntity);
				}
				else
				{
					activeEntity.position = new Vector2Int(num2, activeEntity.position.y);
				}
				int num3 = activeEntity.position.x + activeEntity.sprite.size.x;
				int num4 = screenBounds.maxX - 1 - num3;
				if (num4 < num)
				{
					num = num4;
				}
				if (CheckPlayerCollision(activeEntity))
				{
					if (activeEntity.isPowerUp)
					{
						entitiesToRemove.Add(activeEntity);
						score += 5;
						audio.PlayClip(clipPowerUp);
					}
					else
					{
						GameOver();
					}
				}
			}
			foreach (GameEntity item in entitiesToRemove)
			{
				RemoveEntity(item);
			}
			int num5 = Random.Range(entitySpawnThreshold.x, entitySpawnThreshold.y);
			if (num > num5)
			{
				SpawnRandomEntity();
			}
		}

		private void GameOver()
		{
			audio.StopMusic();
			audio.PlayClip(deathClip);
			canTick = false;
			bool flag = score > highScore;
			if (flag)
			{
				highScore = score;
				if (saveData == null)
				{
					saveData = new JObject();
				}
				saveData["HighScore"] = highScore;
				SaveGame();
			}
			if (deathCoro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Stop(deathCoro);
			}
			deathCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(DeathCoroutine(flag));
		}

		private IEnumerator DeathCoroutine(bool achievement)
		{
			int duration = 5;
			bool invert = true;
			audio.StopMusic();
			while (duration-- > 0)
			{
				yield return WaitFor.Seconds(0.3f);
				canRestart = true;
				screen.DrawSprite(dudeSpriteWrapped.sprite, dudeSpriteWrapped.position, includePadding: true, invert);
				if (achievement)
				{
					UpdateScore(high: true, invert);
				}
				invert = !invert;
			}
			yield return WaitFor.Seconds(0.5f);
			deathCoro = null;
			EndGame();
		}

		private void SpawnRandomEntity()
		{
			bool isPowerUp = (entitiesRemoved > 0 && entitiesRemoved % 20 == 0) || Random.Range(0, 20) == 0;
			SpawnEntity(isPowerUp);
		}

		private void SpawnEntity(bool isPowerUp = false)
		{
			BrickSprite brickSprite;
			Queue<GameEntity> queue;
			if (isPowerUp)
			{
				brickSprite = powerUpSprites[powerUpThick ? 1 : 0];
				queue = inactivePowerUps;
			}
			else
			{
				brickSprite = carSprite;
				queue = inactiveCars;
			}
			int lane = Random.Range(0, 3);
			int x = screenBounds.maxX - 1;
			int num = (laneHeight - brickSprite.size.y) / 2 + -4;
			Vector2Int position = new Vector2Int(x, LaneToHeight(lane) + num);
			GameEntity gameEntity;
			if (queue.Count > 0)
			{
				gameEntity = queue.Dequeue();
				gameEntity.position = position;
				gameEntity.lane = lane;
			}
			else
			{
				gameEntity = new GameEntity(brickSprite, position, isPowerUp, lane);
			}
			activeEntities.Add(gameEntity);
		}

		private void RemoveEntity(GameEntity entity)
		{
			bool isPowerUp = entity.isPowerUp;
			activeEntities.Remove(entity);
			if (isPowerUp)
			{
				inactivePowerUps.Enqueue(entity);
			}
			else
			{
				inactiveCars.Enqueue(entity);
			}
			entitiesRemoved++;
			if (!isPowerUp)
			{
				score++;
				audio.PlayClip(scoreClip);
			}
		}

		private void RemoveAllActiveEntities()
		{
			foreach (GameEntity activeEntity in activeEntities)
			{
				if (activeEntity.isPowerUp)
				{
					inactivePowerUps.Enqueue(activeEntity);
				}
				else
				{
					inactiveCars.Enqueue(activeEntity);
				}
			}
			activeEntities.Clear();
		}

		private bool CheckPlayerCollision(GameEntity entity)
		{
			if (dudeSpriteWrapped.lane != entity.lane)
			{
				return false;
			}
			int x = dudeSpriteWrapped.position.x;
			int x2 = entity.position.x;
			int x3 = dudeSpriteWrapped.sprite.size.x;
			int x4 = entity.sprite.size.x;
			if (x + x3 > x2)
			{
				return x < x2 + x4;
			}
			return false;
		}

		private void UpdateScore(bool high, bool invert = false)
		{
			int num = (high ? highScore : score);
			for (int i = 0; i < 4; i++)
			{
				int num2 = 1;
				for (int j = 0; j < i; j++)
				{
					num2 *= 10;
				}
				int num3 = num / num2 % 10;
				BrickSprite brickSprite = numberSprites[num3];
				Vector2Int size = brickSprite.size;
				int x = ((!high) ? (screenBounds.maxX - (i + 1) * (size.x + 1)) : (screenBounds.minX + (4 - i - 1) * (size.x + 1)));
				Vector2Int spritePosition = new Vector2Int(x, 6);
				screen.DrawSprite(brickSprite, spritePosition, includePadding: false, invert);
			}
		}
	}
}
