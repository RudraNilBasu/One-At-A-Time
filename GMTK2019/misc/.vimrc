colorscheme desert
set guifont=Consolas:h14

:map <F7> :tabp<CR>
:map <F8> :tabn<CR>

:map <F7> :tabp<CR>
:map <F8> :tabn<CR>

:map <space> viw


" show existing tab with 4 spaces width
set tabstop=4
" when indenting with '>', use 4 spaces width
set shiftwidth=4
" On pressing tab, insert 4 spaces
set expandtab

" Searching
set incsearch " search as chars are entered
set hlsearch  " highlight matches
" turn off search highlight \<space> to turn off highlight
nnoremap <leader><space> :nohlsearch<CR>


map <F5> :%s///gn <CR>
map <F6> :%s/word/replace/g
map <C-a> <esc>ggVG<CR>
nnoremap - dd
inoremap <c-u> <esc>viwUi
inoremap <c-d> <esc>ddi
nnoremap <c-u> viwU
inoremap <c-v> <esc>viw
inoremap <c-space> <esc>viw
map <F10> :FZF<CR>
map <F9> :Ag<CR>

function SetTabValue(value)
    let cm1 = 'set shiftwidth=' . a:value
    let cm2 = 'set tabstop=' . a:value
    execute cm1
    execute cm2
endfunction

function TotalLines()
    echom line('$')
endfunction

function ToggleLineNumbers()
  set invnumber
  set invrelativenumber
endfunction

function ToggleDND()
  set invcursorline
  set invcursorcolumn
  call ToggleLineNumbers()
endfunction

function StartDND()
  set nocursorline
  set nocursorcolumn
  set updatetime=100
  let g:gitgutter_enabled = 0
  set nonumber
  set norelativenumber
endfunction

call StartDND()

call pathogen#infect()

" Add spaces after comment delimiters by default
let g:NERDSpaceDelims = 1

