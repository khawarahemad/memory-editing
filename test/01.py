import requests

token = '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'
repo_url = 'https://api.github.com/repos/khawarahemad/memory-editing/contents/'

headers = {
    'Authorization': f'token {token}',
}

# Example to list files in the repository
response = requests.get(repo_url, headers=headers)
files = response.json()

for file in files:
    print(file['name'])