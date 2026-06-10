using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class STMTextInfo
{
	public CharacterInfo ch;

	public Vector3 pos;

	public Vector3 offset;

	public float lineSpacing;

	public bool isEndOfParagraph;

	public float readTime = -1f;

	public float unreadTime = -1f;

	public int line;

	public int rawIndex;

	public float indent;

	public STMDrawAnimData drawAnimData;

	public Vector2 size;

	public SuperTextMesh.Alignment alignment;

	public SuperTextMesh.DrawOrder drawOrder;

	public List<string> ev = new List<string>();

	public List<string> ev2 = new List<string>();

	public STMColorData colorData;

	public STMGradientData gradientData;

	public STMTextureData textureData;

	public STMDelayData delayData;

	public STMWaveData waveData;

	public STMJitterData jitterData;

	public float readDelay;

	public STMAudioClipData audioClipData;

	public bool stopPreviousSound;

	public SuperTextMesh.PitchMode pitchMode;

	public float overridePitch;

	public float minPitch;

	public float maxPitch;

	public float speedReadPitch;

	public STMFontData fontData;

	public STMQuadData quadData;

	public bool isQuad;

	public int quadIndex = -1;

	public STMMaterialData materialData;

	public STMSoundClipData soundClipData;

	public int IdxIdentifier;

	public bool InfoInUse;

	private int chGlyphIndex = -1;

	public int chMinX;

	public int chMaxX;

	public int chMinY;

	public int chMaxY;

	private int chAdvance;

	private Vector2 chUvBottomLeft = Vector2.zero;

	private Vector2 chUvBottomRight = Vector2.zero;

	private Vector2 chUvTopLeft = Vector2.zero;

	private Vector2 chUvTopRight = Vector2.zero;

	public int chSize = 1;

	public bool submeshChange;

	public bool invoked;

	private Vector2 uvMidReturn = Vector2.zero;

	private Vector3 _topLeftVert;

	private Vector3 _topRightVert;

	private Vector3 _bottomRightVert;

	private Vector3 _bottomLeftVert;

	private Vector3 _middle;

	private Vector3 RelativePos_ReturnVal = Vector3.zero;

	private float RelativePos_Multiplier;

	private Vector3 RelativePos2_ReturnVal = Vector3.zero;

	private Vector3 Advance_ReturnVal = Vector3.zero;

	public char character => Convert.ToChar(chGlyphIndex);

	public float uvHeight
	{
		get
		{
			if (chUvBottomLeft.x != chUvTopLeft.x)
			{
				return chUvTopLeft.y - chUvTopRight.y;
			}
			return chUvBottomLeft.y - chUvTopLeft.y;
		}
	}

	public float uvWidth
	{
		get
		{
			if (chUvBottomRight.y != chUvBottomLeft.y)
			{
				return chUvTopLeft.x - chUvBottomLeft.x;
			}
			return chUvBottomRight.x - chUvBottomLeft.x;
		}
	}

	public Vector2 uvMid
	{
		get
		{
			if (chUvTopLeft.x != chUvBottomLeft.x)
			{
				uvMidReturn.x = (chUvTopLeft.x + chUvBottomLeft.x) * 0.5f;
				uvMidReturn.y = (chUvTopLeft.y + chUvTopRight.y) * 0.5f;
			}
			else
			{
				uvMidReturn.x = (chUvTopLeft.x + chUvTopRight.x) * 0.5f;
				uvMidReturn.y = (chUvTopLeft.y + chUvBottomLeft.y) * 0.5f;
			}
			return uvMidReturn;
		}
	}

	public Vector2 ratio
	{
		get
		{
			Vector2 zero = Vector2.zero;
			if (isQuad)
			{
				zero.x = quadData.size.x;
				zero.y = quadData.size.y;
			}
			else
			{
				zero.x = uvWidth;
				zero.y = uvHeight;
			}
			return zero;
		}
	}

	public Vector3 TopLeftVert
	{
		get
		{
			if (isQuad)
			{
				return RelativePos2(quadData.TopLeftVert);
			}
			_topLeftVert.x = chMinX;
			_topLeftVert.y = chMaxY;
			_topLeftVert.z = 0f;
			return RelativePos(_topLeftVert);
		}
	}

	public Vector3 TopRightVert
	{
		get
		{
			if (isQuad)
			{
				return RelativePos2(quadData.TopRightVert);
			}
			_topRightVert.x = chMaxX;
			_topRightVert.y = chMaxY;
			_topRightVert.z = 0f;
			return RelativePos(_topRightVert);
		}
	}

	public Vector3 BottomRightVert
	{
		get
		{
			if (isQuad)
			{
				return RelativePos2(quadData.BottomRightVert);
			}
			_bottomRightVert.x = chMaxX;
			_bottomRightVert.y = chMinY;
			_bottomRightVert.z = 0f;
			return RelativePos(_bottomRightVert);
		}
	}

	public Vector3 BottomLeftVert
	{
		get
		{
			if (isQuad)
			{
				return RelativePos2(quadData.BottomLeftVert);
			}
			_bottomLeftVert.x = chMinX;
			_bottomLeftVert.y = chMinY;
			_bottomLeftVert.z = 0f;
			return RelativePos(_bottomLeftVert);
		}
	}

	public Vector3 Middle
	{
		get
		{
			_middle.x = Mathf.Lerp(TopLeftVert.x, BottomRightVert.x, 0.5f);
			_middle.y = Mathf.Lerp(TopLeftVert.y, BottomLeftVert.y, 0.5f) + lineSpacing - 1f;
			return _middle;
		}
	}

	public float RelativeWidth
	{
		get
		{
			if (isQuad)
			{
				return quadData.size.x * size.x;
			}
			return (float)chMaxX * (size.x / (float)chSize);
		}
	}

	public void UpdateCachedValuesIfChanged(bool force)
	{
		if (force || chGlyphIndex != ch.index)
		{
			chGlyphIndex = ch.index;
			chMinX = ch.minX;
			chMaxX = ch.maxX;
			chMinY = ch.minY;
			chMaxY = ch.maxY;
			chAdvance = ch.advance;
			chSize = ch.size;
			chUvBottomLeft = ch.uvBottomLeft;
			chUvBottomRight = ch.uvBottomRight;
			chUvTopLeft = ch.uvTopLeft;
			chUvTopRight = ch.uvTopRight;
		}
		chSize = ((ch.size == 0) ? 1 : ch.size);
	}

	public Vector3 RelativePos(Vector3 yeah)
	{
		RelativePos_Multiplier = size.y / (float)chSize;
		RelativePos_ReturnVal.x = pos.x + offset.x + yeah.x * (size.x / (float)chSize);
		RelativePos_ReturnVal.y = pos.y + offset.y + yeah.y * RelativePos_Multiplier;
		RelativePos_ReturnVal.z = pos.z + offset.z + yeah.z * RelativePos_Multiplier;
		return RelativePos_ReturnVal;
	}

	public Vector3 RelativePos2(Vector3 yeah)
	{
		RelativePos2_ReturnVal.x = pos.x + offset.x + yeah.x * size.x;
		RelativePos2_ReturnVal.y = pos.y + offset.y + yeah.y * size.y;
		RelativePos2_ReturnVal.z = pos.z + offset.z + yeah.z;
		return RelativePos2_ReturnVal;
	}

	public Vector3 RelativeAdvance(float extraSpacing, float quality)
	{
		return Advance(extraSpacing, quality) + pos;
	}

	public Vector3 RelativeAdvance(float extraSpacing)
	{
		return RelativeAdvance(extraSpacing, chSize);
	}

	public Vector3 Advance(float extraSpacing, float myQuality)
	{
		if (quadData != null)
		{
			Advance_ReturnVal.x = (quadData.size.x + quadData.advance) * size.x + extraSpacing * size.x / myQuality;
			Advance_ReturnVal.y = 0f;
			Advance_ReturnVal.z = 0f;
		}
		else
		{
			Advance_ReturnVal.x = ((float)chAdvance + extraSpacing * size.x) * (size.x / myQuality);
			Advance_ReturnVal.y = 0f;
			Advance_ReturnVal.z = 0f;
		}
		return Advance_ReturnVal;
	}

	public Vector3 Advance(float extraSpacing)
	{
		return Advance(extraSpacing, chSize);
	}

	public STMTextInfo()
	{
		ch = default(CharacterInfo);
		pos = Vector3.zero;
		lineSpacing = 1f;
		isEndOfParagraph = false;
		offset.x = 0f;
		offset.y = 0f;
		offset.z = 0f;
		line = 0;
		rawIndex = 0;
		indent = 0f;
		size.x = 16f;
		size.y = 16f;
		ev.Clear();
		ev2.Clear();
		readTime = -1f;
		unreadTime = -1f;
		quadIndex = -1;
		isQuad = false;
		submeshChange = false;
		invoked = false;
	}

	public STMTextInfo(SuperTextMesh stm)
	{
		SetValues(stm);
	}

	public void SetValues(SuperTextMesh stm)
	{
		lineSpacing = stm.lineSpacing;
		isEndOfParagraph = false;
		ch.style = stm.style;
		gradientData = null;
		colorData = null;
		textureData = null;
		delayData = null;
		waveData = null;
		jitterData = null;
		audioClipData = null;
		fontData = null;
		quadData = null;
		offset.x = 0f;
		offset.y = 0f;
		offset.z = 0f;
		indent = 0f;
		rawIndex = 0;
		size.x = stm.size;
		size.y = stm.size;
		ev.Clear();
		ev2.Clear();
		alignment = stm.alignment;
		stopPreviousSound = stm.stopPreviousSound;
		pitchMode = stm.pitchMode;
		overridePitch = stm.overridePitch;
		minPitch = stm.minPitch;
		maxPitch = stm.maxPitch;
		speedReadPitch = stm.speedReadPitch;
		readDelay = stm.readDelay;
		if (drawAnimData != null)
		{
			if (drawAnimData.name != stm.drawAnimName)
			{
				drawAnimData = Resources.Load<STMDrawAnimData>("STMDrawAnims/" + stm.drawAnimName);
				if (drawAnimData == null)
				{
					STMDrawAnimData[] array = Resources.LoadAll<STMDrawAnimData>("STMDrawAnims");
					if (array.Length != 0)
					{
						drawAnimData = array[0];
					}
				}
			}
		}
		else
		{
			drawAnimData = Resources.Load<STMDrawAnimData>("STMDrawAnims/" + stm.drawAnimName);
			if (drawAnimData == null)
			{
				STMDrawAnimData[] array2 = Resources.LoadAll<STMDrawAnimData>("STMDrawAnims");
				if (array2.Length != 0)
				{
					drawAnimData = array2[0];
				}
			}
		}
		drawOrder = stm.drawOrder;
		quadIndex = -1;
		isQuad = false;
		materialData = null;
		soundClipData = null;
		quadIndex = -1;
		submeshChange = false;
		invoked = false;
		chSize = stm.quality;
	}

	public STMTextInfo(STMTextInfo clone, CharacterInfo ch)
		: this(clone)
	{
		this.ch = ch;
		quadData = null;
		isQuad = false;
	}

	public STMTextInfo(STMTextInfo clone)
	{
		SetValues(clone);
	}

	public void SetValues(STMTextInfo clone)
	{
		lineSpacing = clone.lineSpacing;
		isEndOfParagraph = clone.isEndOfParagraph;
		ch = clone.ch;
		pos = clone.pos;
		offset.x = clone.offset.x;
		offset.y = clone.offset.y;
		offset.z = clone.offset.z;
		line = clone.line;
		rawIndex = clone.rawIndex;
		indent = clone.indent;
		if (clone.ev.Count > 0)
		{
			ev = new List<string>(clone.ev);
		}
		if (clone.ev2.Count > 0)
		{
			ev2 = new List<string>(clone.ev2);
		}
		colorData = clone.colorData;
		gradientData = clone.gradientData;
		textureData = clone.textureData;
		size = clone.size;
		delayData = clone.delayData;
		waveData = clone.waveData;
		jitterData = clone.jitterData;
		alignment = clone.alignment;
		readTime = clone.readTime;
		unreadTime = clone.unreadTime;
		drawAnimData = clone.drawAnimData;
		audioClipData = clone.audioClipData;
		stopPreviousSound = clone.stopPreviousSound;
		pitchMode = clone.pitchMode;
		overridePitch = clone.overridePitch;
		minPitch = clone.minPitch;
		maxPitch = clone.maxPitch;
		speedReadPitch = clone.speedReadPitch;
		readDelay = clone.readDelay;
		drawOrder = clone.drawOrder;
		fontData = clone.fontData;
		quadData = clone.quadData;
		isQuad = clone.isQuad;
		materialData = clone.materialData;
		soundClipData = clone.soundClipData;
		quadIndex = clone.quadIndex;
		submeshChange = clone.submeshChange;
		invoked = false;
		chSize = clone.chSize;
	}
}
