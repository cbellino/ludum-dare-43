﻿using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "LD43/Settings", order = 1)]
public class GameSettings : ScriptableObject
{
	public List<GameObject> levels = new List<GameObject>();
	public List<SacrificeData> sacrifices = new List<SacrificeData>();
	public List<GameObject> enemyPrefabs = new List<GameObject>();
	public ProjectileFacade projectilesPrefab;
	public List<Sprite> projectilesSprites = new List<Sprite>();

	public PlayerSettings PlayerSettings;
}

[Serializable]
public class PlayerSettings
{
	public Wenk.Settings Wenk;
}
