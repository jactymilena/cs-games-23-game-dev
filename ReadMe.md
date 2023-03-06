# Projet Unity CS Games UQAC H23

Ce projet Unity utilise la configuration de base URP et le [Starter Assets - First Person Character Controller](https://assetstore.unity.com/packages/essentials/starter-assets-first-person-character-controller-196525)

![first-person-starter.jpg](./docs/images/first-person-starter.jpg)

## Prérequis

- [Unity 2021.3.14f1](https://unity.com/releases/editor/whats-new/2021.3.14#release-notes)

## Dans ce projet

* [Assets](Assets/): Contient les assets du projet
* [Assets/StarterAssets](Assets/StarterAssets/): Contient les assets de [Starter Assets - First Person Character Controller](https://assetstore.unity.com/packages/essentials/starter-assets-first-person-character-controller-196525)
* [.github/workflows](.github/workflows/): Contient les fichiers de configuration de Github Actions (GameCI)

## Configuration GameCI GitHub Actions

![GameCI](./docs/images/gameci.png)

Ce projet contient un workflow [GameCI](https://game.ci/) de base pour compiler le projet à l'aide de Github Actions. Pour plus d'information sur l'utilisation de GameCI avec Github Actions, voir la [Documentation GameCI](https://game.ci/docs/github/getting-started).

![GameCI](./docs/images/actions.png)

### Activation

Si vous désirez utiliser GameCI pour ce projet, il vous suffit d'accomplir [la partie "Activation" de la documentation GameCI](https://game.ci/docs/github/activation). Vous n'avez qu'à suivre la partie [Personal license - Converting into a license](https://game.ci/docs/github/activation#converting-into-a-license) de la documentation. Vous aurez besoin d'un compte Unity (courriel et mot de passe)

Dans les réglages Github Actions, vous devriez avoir les secrets suivants:

* `UNITY_LICENSE`: Le contenu du fichier `Unity_v2021.x.ulf` (voir [Personal license - Converting into a license](https://game.ci/docs/github/activation#converting-into-a-license))
* `UNITY_EMAIL`: Votre courriel Unity
* `UNITY_PASSWORD`: Votre mot de passe Unity

![Github Actions Secrets](./docs/images/github-actions-secrets.jpg)

## Projet d'exemple créé par

**[Totema Studio](https://totemastudio.com/)**

[![Totema Studio](./docs/images/totemastudio.png)](https://totemastudio.com/)

