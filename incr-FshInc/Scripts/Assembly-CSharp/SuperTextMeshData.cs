using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Text Data", menuName = "Super Text Mesh/Super Text Mesh Data", order = 0)]
public class SuperTextMeshData : ScriptableObject
{
	[HideInInspector]
	public bool showEffectsFoldout;

	[HideInInspector]
	public bool showWavesFoldout;

	public Dictionary<string, STMWaveData> waves = new Dictionary<string, STMWaveData>();

	[HideInInspector]
	public bool showJittersFoldout;

	public Dictionary<string, STMJitterData> jitters = new Dictionary<string, STMJitterData>();

	[HideInInspector]
	public bool showDrawAnimsFoldout;

	public Dictionary<string, STMDrawAnimData> drawAnims = new Dictionary<string, STMDrawAnimData>();

	[HideInInspector]
	public bool showTextColorFoldout;

	[HideInInspector]
	public bool showColorsFoldout;

	public Dictionary<string, STMColorData> colors = new Dictionary<string, STMColorData>();

	[HideInInspector]
	public bool showGradientsFoldout;

	public Dictionary<string, STMGradientData> gradients = new Dictionary<string, STMGradientData>();

	[HideInInspector]
	public bool showTexturesFoldout;

	public Dictionary<string, STMTextureData> textures = new Dictionary<string, STMTextureData>();

	[HideInInspector]
	public bool showInlineFoldout;

	[HideInInspector]
	public bool showDelaysFoldout;

	public Dictionary<string, STMDelayData> delays = new Dictionary<string, STMDelayData>();

	[HideInInspector]
	public bool showVoicesFoldout;

	public Dictionary<string, STMVoiceData> voices = new Dictionary<string, STMVoiceData>();

	[HideInInspector]
	public bool showFontsFoldout;

	public Dictionary<string, STMFontData> fonts = new Dictionary<string, STMFontData>();

	[HideInInspector]
	public bool showSoundClipsFoldout;

	public Dictionary<string, STMSoundClipData> soundClips = new Dictionary<string, STMSoundClipData>();

	[HideInInspector]
	public bool showAudioClipsFoldout;

	public Dictionary<string, STMAudioClipData> audioClips = new Dictionary<string, STMAudioClipData>();

	[HideInInspector]
	public bool showQuadsFoldout;

	public Dictionary<string, STMQuadData> quads = new Dictionary<string, STMQuadData>();

	[HideInInspector]
	public bool showMaterialsFoldout;

	public Dictionary<string, STMMaterialData> materials = new Dictionary<string, STMMaterialData>();

	[HideInInspector]
	public bool showAutomaticFoldout;

	[HideInInspector]
	public bool showAutoClipsFoldout;

	public Dictionary<string, STMAutoClipData> autoClips = new Dictionary<string, STMAutoClipData>();

	[HideInInspector]
	public bool showAutoDelaysFoldout;

	public Dictionary<string, STMAutoDelayData> autoDelays = new Dictionary<string, STMAutoDelayData>();

	[HideInInspector]
	public bool showMasterFoldout = true;

	[Tooltip("This disables waves and jitters from effecting text position, which might be hard for some users to read.")]
	public bool disableAnimatedText;

	public Font defaultFont;

	public Color boundsColor = Color.blue;

	public Color textBoundsColor = Color.yellow;

	public Color finalTextBoundsColor = Color.grey;

	public float superscriptOffset = 0.5f;

	public float superscriptSize = 0.5f;

	public float subscriptOffset = -0.2f;

	public float subscriptSize = 0.5f;

	public Font inspectorFont;

	public void RebuildDictionaries()
	{
		waves = Resources.LoadAll<STMWaveData>("STMWaves").ToDictionary((STMWaveData x) => x.name, (STMWaveData x) => x);
		jitters = Resources.LoadAll<STMJitterData>("STMJitters").ToDictionary((STMJitterData x) => x.name, (STMJitterData x) => x);
		drawAnims = Resources.LoadAll<STMDrawAnimData>("STMDrawAnims").ToDictionary((STMDrawAnimData x) => x.name, (STMDrawAnimData x) => x);
		colors = Resources.LoadAll<STMColorData>("STMColors").ToDictionary((STMColorData x) => x.name, (STMColorData x) => x);
		gradients = Resources.LoadAll<STMGradientData>("STMGradients").ToDictionary((STMGradientData x) => x.name, (STMGradientData x) => x);
		textures = Resources.LoadAll<STMTextureData>("STMTextures").ToDictionary((STMTextureData x) => x.name, (STMTextureData x) => x);
		delays = Resources.LoadAll<STMDelayData>("STMDelays").ToDictionary((STMDelayData x) => x.name, (STMDelayData x) => x);
		voices = Resources.LoadAll<STMVoiceData>("STMVoices").ToDictionary((STMVoiceData x) => x.name, (STMVoiceData x) => x);
		fonts = Resources.LoadAll<STMFontData>("STMFonts").ToDictionary((STMFontData x) => x.name, (STMFontData x) => x);
		soundClips = Resources.LoadAll<STMSoundClipData>("STMSoundClips").ToDictionary((STMSoundClipData x) => x.name, (STMSoundClipData x) => x);
		audioClips = Resources.LoadAll<STMAudioClipData>("STMAudioClips").ToDictionary((STMAudioClipData x) => x.name, (STMAudioClipData x) => x);
		quads = Resources.LoadAll<STMQuadData>("STMQuads").ToDictionary((STMQuadData x) => x.name, (STMQuadData x) => x);
		materials = Resources.LoadAll<STMMaterialData>("STMMaterials").ToDictionary((STMMaterialData x) => x.name, (STMMaterialData x) => x);
		autoClips = (from x in Resources.LoadAll<STMAutoClipData>("STMAutoClips")
			group x by (x.type != STMAutoClipData.Type.Quad) ? x.character.ToString() : x.quadName into x
			select x.First()).ToDictionary((STMAutoClipData x) => (x.type != STMAutoClipData.Type.Quad) ? x.character.ToString() : x.quadName, (STMAutoClipData x) => x);
		autoDelays = (from x in Resources.LoadAll<STMAutoDelayData>("STMAutoDelays")
			group x by (x.type != STMAutoDelayData.Type.Quad) ? x.character.ToString() : x.quadName into x
			select x.First()).ToDictionary((STMAutoDelayData x) => (x.type != STMAutoDelayData.Type.Quad) ? x.character.ToString() : x.quadName, (STMAutoDelayData x) => x);
	}
}
