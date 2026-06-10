using System;
using System.Collections.Generic;
using UnityEngine;

public class TwitchOAuthController : MonoBehaviour
{
	private static TwitchOAuthController _instance;

	private const string TwitchAuthUrl = "https://id.twitch.tv/oauth2/authorize";

	private const string ClientID = "bq0wyxhwa7xjlyomjjdv2o6wun6l2t";

	private const string TwitchRedirectURL = "http://localhost:8085/";

	private string _twitchAuthStateVerify;

	private string _authToken;

	private Queue<string> _tokenQueue;

	public bool _hasAuth;

	private bool _tryingValidation;

	public static TwitchOAuthController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void QueueAuthorizationToken()
	{
	}

	public string GetAuthToken()
	{
		return null;
	}

	public string GetClientID()
	{
		return null;
	}

	public void TryTwitchAuthorization()
	{
	}

	public void InitiateTwitchAuth()
	{
	}

	private void StartLocalWebserver()
	{
	}

	private void IncomingHttpRequest(IAsyncResult result)
	{
	}

	private void IncomingAuth(IAsyncResult ar)
	{
	}
}
