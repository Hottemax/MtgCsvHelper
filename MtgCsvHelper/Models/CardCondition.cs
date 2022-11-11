﻿namespace MtgCsvHelper.Models;

public class CardCondition : Enumeration
{
	public static readonly CardCondition MINT = new(1, "Mint");
	public static readonly CardCondition NEAR_MINT = new(2, "NearMint");
	public static readonly CardCondition EXCELLENT = new(3, "Excellent");
	public static readonly CardCondition GOOD = new(4, "Good");
	public static readonly CardCondition LIGHTLY_PLAYED = new(5, "LightlyPlayed");
	public static readonly CardCondition PLAYED = new(6, "Played");
	public static readonly CardCondition POOR = new(7, "Poor");

	protected CardCondition(int id, string name) : base(id, name) { }
}
