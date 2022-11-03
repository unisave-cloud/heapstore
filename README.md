Unisave Heapstore
=================

<a href="https://unisave.cloud/" target="_blank">
    <img alt="Website" src="https://img.shields.io/badge/Website-unisave.cloud-blue">
</a>
<a href="https://discord.gg/XV696Tp" target="_blank">
    <img alt="Discord" src="https://img.shields.io/discord/564878084499832839?label=Discord">
</a>

Heapstore is an official Unisave asset that provides a cloud database, similar to Unity's `PlayerPrefs`, that requires minimal server-side code. It requires the core [Unisave Asset](https://assetstore.unity.com/packages/slug/142705) to function.


## Development

1. Clone the repository
2. Open in Unity
3. Install the core Unisave Asset via the Asset Store
4. There should be no errors now


### Features to implement

- imperative API
    - document API
        - get (KEY known, fetches the document or signals it is missing)
        - set (KEY known, create or overwrite entire document)
        - update (KEY known, create or merge)
        - add (KEY to be created, create document)
    - query API
        - return documents based on a query
- declarative API
    - watch a query and report modifications
- latency compensation
    - document modifications should update watching queries on the same client immediately
- real-time updates
    - document modifications should ping watching queries via the broadcasting system
- security
    - authentication
    - security rules
- quality of service
    - handle network outages
