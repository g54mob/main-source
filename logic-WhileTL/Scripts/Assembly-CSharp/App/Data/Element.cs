using System.Collections.Generic;
using ReinforcementLearning.Environment;
using UnityEngine;

namespace App.Data
{
	public class Element
	{
		public int recursionDepth;

		public Dictionary<int, int> blocksProcessed = new Dictionary<int, int>();

		public int revealScore;

		public bool revealed = true;

		public bool Test;

		public float timeInBlock;

		public bool Try;

		public float exitTime;

		public int customOutSocket;

		public int inputNum;

		public float startTime;

		public bool stopped;

		public float error;

		public int curDepth;

		public float spawnInDataTime;

		public bool startup;

		public int socketIn;

		public int socketOut;

		public string spriteName;

		public int ColorId;

		public int RealColorId;

		public int ShapeId;

		public bool isCarElem;

		public bool hideColor;

		public List<char> word;

		public string colorsQueue;

		public List<char> truePredict;

		public int batchSize;

		public int iterWord;

		public CellObjects trueCellObject;

		public string predictedObject = "unknown";

		public string beforeZIPSprite = "";

		public string SpriteName
		{
			get
			{
				if (spriteName != null)
				{
					return spriteName;
				}
				if (beforeZIPSprite != "")
				{
					return beforeZIPSprite;
				}
				if (isCarElem)
				{
					return Logic.GetCarObjectTreeHierarchyByKeyName(predictedObject).smallSpriteName;
				}
				return "SHAPE" + ShapeId;
			}
		}

		public void SetZIPSprite(string spriteName)
		{
			beforeZIPSprite = spriteName;
		}

		public bool IsZIPElement()
		{
			return beforeZIPSprite != "";
		}

		public Color GetColor(StaticData _staticData)
		{
			if (!revealed)
			{
				return Logic.GetColor("SETTINGSGRAY");
			}
			if (word == null)
			{
				if (beforeZIPSprite != "")
				{
					return Color.white;
				}
				if (spriteName != null)
				{
					return Logic.GetColor("WHITE");
				}
				return Logic.GetColor(_staticData.Colors[ColorId].KeyName);
			}
			if (colorsQueue != null)
			{
				return Logic.GetColor(_staticData.Colors[colorsQueue[iterWord] - 48].KeyName);
			}
			return Logic.GetColor("WHITE");
		}

		public Element()
		{
		}

		public Element(string spriteName)
		{
			this.spriteName = spriteName;
		}

		public void AddToRNNHolder(Element el)
		{
			error = el.error;
			startTime = el.startTime;
			spawnInDataTime = el.spawnInDataTime;
			revealScore = el.revealScore;
			revealed = revealScore <= 0;
			truePredict = el.truePredict;
			foreach (char item in el.word)
			{
				word.Add(item);
			}
		}

		public void MoveToNextBatch(int step)
		{
			int num = Mathf.Min(step, word.Count);
			iterWord++;
			if (word.Count >= batchSize)
			{
				for (int i = 0; i < num; i++)
				{
					word.RemoveAt(0);
				}
			}
		}

		public Element(CellObjects trueCellObject = CellObjects.empty, string predictedObject = "unknown", bool test = false, bool isCarElem = true, int socketIn = 0)
		{
			this.isCarElem = isCarElem;
			this.trueCellObject = trueCellObject;
			this.predictedObject = predictedObject;
			Test = test;
			Try = false;
			customOutSocket = -1;
			exitTime = -1f;
			inputNum = -1;
			startTime = -1f;
			stopped = false;
			spawnInDataTime = 0f;
			error = 0f;
			this.socketIn = socketIn;
			curDepth = 0;
			startup = false;
			recursionDepth = 0;
			blocksProcessed = new Dictionary<int, int>();
		}

		public void ApplyRevealScore(int score)
		{
			revealScore -= score;
			CheckRevealColor();
		}

		public void CheckRevealColor()
		{
			if (colorsQueue != null)
			{
				revealed = revealScore <= 0;
				iterWord %= colorsQueue.Length;
				if (revealed)
				{
					ColorId = colorsQueue[iterWord] - 48;
				}
			}
		}

		public Element(int color, int shape, bool test, ConstructionQuest cq = null, List<char> w = null, List<char> predict = null, int iterWord = 0, int socketIn = 0, bool isCarElem = false, CellObjects trueCellObject = CellObjects.empty, string predictedObject = "unknown")
		{
			this.isCarElem = isCarElem;
			this.trueCellObject = trueCellObject;
			this.predictedObject = predictedObject;
			ColorId = color;
			RealColorId = color;
			ShapeId = shape;
			Test = test;
			Try = false;
			customOutSocket = -1;
			exitTime = -1f;
			inputNum = -1;
			startTime = -1f;
			stopped = false;
			spawnInDataTime = 0f;
			error = 0f;
			this.iterWord = iterWord;
			this.socketIn = socketIn;
			if (cq != null)
			{
				error = Random.Range(cq.MinError, cq.MaxError);
				if (cq.RevealScore > 0)
				{
					revealScore = cq.RevealScore;
					revealed = false;
				}
				CheckRevealColor();
			}
			word = Logic.Clone<List<char>>(w);
			truePredict = Logic.Clone<List<char>>(predict);
			curDepth = 0;
			startup = false;
			recursionDepth = 0;
			blocksProcessed = new Dictionary<int, int>();
		}

		public Element(Element el)
		{
			hideColor = el.hideColor;
			isCarElem = el.isCarElem;
			trueCellObject = el.trueCellObject;
			predictedObject = (string)predictedObject.Clone();
			ColorId = el.ColorId;
			RealColorId = el.RealColorId;
			ShapeId = el.ShapeId;
			Test = el.Test;
			Try = el.Try;
			socketIn = el.socketIn;
			customOutSocket = el.customOutSocket;
			exitTime = el.exitTime;
			inputNum = el.inputNum;
			startTime = el.startTime;
			stopped = el.stopped;
			spawnInDataTime = el.spawnInDataTime;
			error = el.error;
			revealed = el.revealed;
			batchSize = el.batchSize;
			revealScore = el.revealScore;
			colorsQueue = el.colorsQueue;
			iterWord = el.iterWord;
			if (el.truePredict != null)
			{
				truePredict = (List<char>)el.truePredict.Clone();
				word = (List<char>)el.word.Clone();
				CheckRevealColor();
			}
			curDepth = el.curDepth;
			startup = el.startup;
			recursionDepth = el.recursionDepth;
			blocksProcessed = el.blocksProcessed;
			if (spriteName != null)
			{
				spriteName = (string)el.spriteName.Clone();
			}
		}
	}
}
