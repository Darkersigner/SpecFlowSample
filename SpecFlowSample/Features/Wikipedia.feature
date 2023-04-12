Feature: Wikipedia
Check how www.wikipedia.org works

    Scenario Outline: Open site, check title and close
        Given set browser <browser>
        And set save screenshots true
        And open site https://www.wikipedia.org/
        Then title browser page is 'Wikipedia'

        Examples:
          | browser |
          | Chrome  |
          | FireFox |

    Scenario Outline: Open site, send text to search and check title on opened page
        Given set browser Chrome
        And open site https://www.wikipedia.org/
        And write to search '<text>'
        And choose language '<language>'
        And click search button
        Then title page is '<title>'

        Examples:
          | text   | language | title       |
          | Hello  | English  | Hello      |
          | Привет | Русский  | Приветствие |