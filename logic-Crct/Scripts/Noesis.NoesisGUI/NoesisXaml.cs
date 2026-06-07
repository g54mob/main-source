using System;
using UnityEngine;
using UnityEngine.Video;

public class NoesisXaml : ScriptableObject
{
	[Serializable]
	public struct Xaml
	{
		public string uri;

		public NoesisXaml xaml;
	}

	[Serializable]
	public struct Font
	{
		public string uri;

		public NoesisFont font;
	}

	[Serializable]
	public struct Texture
	{
		public string uri;

		public UnityEngine.Texture texture;
	}

	[Serializable]
	public struct Audio
	{
		public string uri;

		public AudioClip audio;
	}

	[Serializable]
	public struct Video
	{
		public string uri;

		public VideoClip video;
	}

	[Serializable]
	public struct Shader
	{
		public string uri;

		public NoesisShader shader;
	}

	public string uri;

	public byte[] content;

	public Xaml[] xamls;

	public Font[] fonts;

	public Texture[] textures;

	public Audio[] audios;

	public Video[] videos;

	public Shader[] shaders;

	private bool _registered;

	private void OnDisable()
	{
	}

	public object Load()
	{
		return null;
	}

	public void RegisterDependencies()
	{
	}

	public void UnregisterDependencies()
	{
	}

	private void _RegisterDependencies()
	{
	}

	private void _UnregisterDependencies()
	{
	}
}
