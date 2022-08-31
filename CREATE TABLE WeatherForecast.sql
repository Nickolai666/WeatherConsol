-- Table: public.WeatherForecast

-- DROP TABLE IF EXISTS public."WeatherForecast";

CREATE TABLE IF NOT EXISTS public."WeatherForecast"
(
    "Id" integer NOT NULL DEFAULT nextval('"WeatherForecast_Id_seq"'::regclass),
    "City" text COLLATE pg_catalog."default" NOT NULL,
    "DateForecast" timestamp without time zone NOT NULL,
    "TemperatureMin" double precision,
    "TemperatureMax" double precision,
    "LiquidDay" double precision,
    "LiquidNight" double precision,
    "WindSpeedDay" double precision,
    "WindSpeedNight" double precision,
    "DLM" timestamp with time zone,
    CONSTRAINT "WeatherForecast_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."WeatherForecast"
    OWNER to postgres;

COMMENT ON TABLE public."WeatherForecast"
    IS 'Прогнозы погоды по городам';