# Registro Visitatori

Applicazione web sviluppata per la gestione degli accessi di visitatori esterni.

Il progetto nasce con l'obiettivo di sostituire un registro cartaceo con una piccola applicazione interna, semplice da usare e pensata per supportare il personale nella registrazione di ingressi, uscite e storico delle visite.

## Obiettivo

L'applicazione permette di gestire in modo più ordinato il flusso dei visitatori all'interno di una struttura, tenendo traccia delle persone presenti e delle visite concluse.

## Funzionalità principali

* Login operatore
* Registrazione di un nuovo visitatore
* Visualizzazione dei visitatori attualmente presenti
* Registrazione dell'uscita del visitatore
* Consultazione dello storico delle visite
* Visualizzazione del motivo della visita
* Eliminazione protetta da password
* Interfaccia semplice e pensata per un utilizzo rapido

## Tecnologie utilizzate

* ASP.NET Core MVC
* C#
* Entity Framework Core
* SQLite
* HTML
* CSS
* Bootstrap

## Struttura del progetto

Il progetto segue il pattern MVC, cioè Model-View-Controller:

* `Models/` contiene i modelli dei dati
* `Views/` contiene le pagine dell'interfaccia utente
* `Controllers/` contiene la logica applicativa
* `Data/` contiene il contesto del database
* `Migrations/` contiene le migrazioni del database
* `wwwroot/` contiene le risorse statiche come CSS e file frontend

## Accesso all'applicazione

L'applicazione prevede un sistema di autenticazione.

Credenziali di test:

* Username: `Luca D.`
* Password: `admin`

Le credenziali sono inserite solo a scopo dimostrativo.

## Come eseguire il progetto

Dalla cartella principale del progetto:

```bash
dotnet run
```

L'applicazione viene avviata in locale e può essere aperta dal browser all'indirizzo indicato nel terminale, ad esempio:

```text
http://localhost:5279
```

## Stato del progetto

Il progetto è funzionante in locale ed è stato testato verificando:

* avvio dell'applicazione;
* accesso con credenziali di test;
* visualizzazione dei visitatori presenti;
* registrazione di nuovi ingressi;
* consultazione dello storico visite;
* interazione con database SQLite.

## Perché è rilevante

Questo progetto mostra la capacità di costruire una piccola applicazione interna partendo da un'esigenza concreta: organizzare un processo operativo, ridurre l'uso del cartaceo e rendere più semplice il controllo delle presenze.

È un esempio di software gestionale semplice, pensato per essere usato in un contesto reale da personale non tecnico.
