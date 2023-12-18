﻿using CsvHelper.Configuration;
using MtgCsvHelper.Converters;

namespace MtgCsvHelper.Maps;

public class CsvToCardMap : ClassMap<PhysicalMtgCard>
{
	public CsvToCardMap(DeckConfig columnConfig)
	{
		Map(card => card.Count).Name(columnConfig.Quantity);
		Map(card => card.Printing.Name).TypeConverter(new CardNameConverter(columnConfig.CardName)).Name(columnConfig.CardName.HeaderName);

		if (!string.IsNullOrEmpty(columnConfig.SetName)) { Map(card => card.Printing.SetName).Name(columnConfig.SetName); }
		if (!string.IsNullOrEmpty(columnConfig.SetCode)) { Map(card => card.Printing.Set).TypeConverter<UpperCaseConverter>().Name(columnConfig.SetCode); }
		if (!string.IsNullOrEmpty(columnConfig.SetNumber)) { Map(card => card.Printing.CollectorNumber).Name(columnConfig.SetNumber); }
		if (columnConfig.Condition is not null) { Map(card => card.Condition).TypeConverter(new CardConditionConverter(columnConfig.Condition)).Name(columnConfig.Condition.HeaderName); }
		if (columnConfig.Finish is not null) { Map(card => card.Foil).TypeConverter(new FinishConverter(columnConfig.Finish)).Name(columnConfig.Finish.HeaderName); }

		Map(card => card.Language).Name("Language").Optional();
		Map(card => card.PriceBought).Name(columnConfig.PriceBought).Optional();
	}
}

public record DeckConfig(
	string Quantity,
	CardNameConfiguration CardName,
	FinishConfiguration? Finish,
	ConditionConfiguration? Condition,
	string SetCode,
	string? SetName,
	string SetNumber,
	string? PriceBought
	);

public record CardNameConfiguration(string HeaderName, bool ShortNames);
public record FinishConfiguration(string HeaderName, string Foil, string Normal, string? Etched);
public record ConditionConfiguration(string HeaderName, string Mint, string NearMint, string Excellent, string Good, string LightlyPlayed, string Played, string Poor);